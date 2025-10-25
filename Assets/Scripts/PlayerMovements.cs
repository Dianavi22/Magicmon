using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [Header("Player Movements Settings")]

    [SerializeField] float speed;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float jumpForce;
    [SerializeField] float fallSpeed;
    [SerializeField] float dashForce;
    [SerializeField] float dashingTime;
    [SerializeField] float dashingCooldown;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    [Header("GFX")]
    [SerializeField] SpriteRenderer playerSprite;

    Rigidbody2D playerRigidbody;
    TrailRenderer trailRenderer;
    private float horizontalDirection;

    private Vector2 dashingDirection;
    private bool canDash;
    private bool isDashing;

    private float originalGravityScale;

    private float jumpCounter;
    private bool isJumping;

    private Vector2 gravityVector;

    private Gradient originalTrailGradient;
    private float originalTrailStartWidth;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        originalGravityScale = playerRigidbody.gravityScale;
        gravityVector = new Vector2(0, -Physics2D.gravity.y);
        dashingDirection = new Vector2(1, 0);
        canDash = true;
        originalTrailGradient = trailRenderer.colorGradient;
        originalTrailStartWidth = trailRenderer.startWidth;
    }

    private void FixedUpdate()
    {

        if (!isDashing)
        {
          playerRigidbody.velocity = new Vector2(horizontalDirection * speed, playerRigidbody.velocity.y);  
        }
        
        //Falling
        if(playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity -= gravityVector * fallSpeed * Time.deltaTime;
        }

        //Jumping
        if (playerRigidbody.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;

            if(jumpCounter > jumpTime)
            {
                isJumping = false;
            }

            float t = jumpCounter / jumpTime;
            float currentJumpMultiplier = jumpMultiplier;

            if(t > 0.5f)
            {
                currentJumpMultiplier = jumpMultiplier * (1 - t);
            }

            playerRigidbody.velocity += gravityVector * currentJumpMultiplier * Time.deltaTime;
        }

        //Dashing
        if (isDashing)
        {
            playerRigidbody.gravityScale = 0;
            playerRigidbody.velocity = dashingDirection.normalized * dashForce;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        if (!isDashing)
        {
            horizontalDirection = context.ReadValue<Vector2>().x;

            if(horizontalDirection != 0)
            {
                playerSprite.flipY = horizontalDirection > 0;
                dashingDirection = new Vector2(horizontalDirection, 0);
            }
            
        }
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isJumping = false;
            jumpCounter = 0;

            if(playerRigidbody.velocity.y > 0)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, playerRigidbody.velocity.y * 0.6f);
            }
        }

        if (context.performed && IsGrounded() && !isDashing)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            isJumping = true;
            jumpCounter = 0;    
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            canDash = false;
            isDashing = true;
            trailRenderer.colorGradient = new Gradient();
            trailRenderer.startWidth = 1f;

            StartCoroutine(StopDashing());
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1,.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private IEnumerator StopDashing()
    {

        yield return new WaitForSeconds(dashingTime);
        playerRigidbody.gravityScale = originalGravityScale;
        isDashing = false;

        trailRenderer.startWidth = originalTrailStartWidth;
        trailRenderer.colorGradient = originalTrailGradient;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
