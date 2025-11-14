using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spellPrefab;
    [SerializeField] GameObject shieldPrefab;

    [SerializeField] Transform spellSpawn;

    [SerializeField] float shieldMaxDuration;
    [SerializeField] float shieldCooldown;

    GameObject _shield;

    [SerializeField]  float _shieldDuration;

    [SerializeField] bool _staticShield;

    float _shielReduceSpeed = 0.01f;
    bool _onShield;
    Vector2 _shieldScale;
    bool _useMaxShield;

    private void Awake()
    {
        _useMaxShield = true;
    }

    private void Start()
    {
        if (_staticShield)
        {
            Instantiate(shieldPrefab, transform.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        if (_onShield)
        {
            if(_shieldDuration < shieldMaxDuration)
            {
                Debug.Log("Shieeelld !!");
                float t = (_shieldDuration * _shielReduceSpeed) / shieldMaxDuration;

                _shieldScale = Vector3.Lerp(_shield.transform.localScale, Vector2.zero, t);
                _shield.transform.localScale = _shieldScale;

                _shieldDuration += Time.deltaTime;
            }
            else
            {
                _onShield = false;
                _useMaxShield = true;

                Destroy(_shield);
            }
            
        }
    }
    public void ActiveAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            spellPrefab.GetComponent<SpriteRenderer>().color = Color.blue;
            spellPrefab.transform.localScale = new Vector3(.5f,.5f,.5f);

            Instantiate(spellPrefab, spellSpawn.position, transform.rotation);
        }
    }

    public void UltimeAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            spellPrefab.GetComponent<SpriteRenderer>().color = Color.red;
            spellPrefab.transform.localScale = new Vector3(1, 1, 1);

            Instantiate(spellPrefab, spellSpawn.position, transform.rotation);
        }
    }

    public void Shield(InputAction.CallbackContext context) {

        if (context.performed && !_onShield)
        {
            _onShield = true;

            if (_useMaxShield)
            {
                _shieldDuration = 0;
                _shieldScale = shieldPrefab.transform.localScale;
                _useMaxShield = false;
            }

            _shield = Instantiate(shieldPrefab, transform.position, transform.rotation);
            _shield.transform.localScale = _shieldScale;

            Debug.Log("shield");
        }

        if (context.canceled)
        {
            _onShield = false;
                
            Destroy(_shield);

            if(_shieldDuration >= shieldMaxDuration) _useMaxShield = true;

            Debug.Log("remove shield");
        }
    }
}
