using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spellPrefab;
    [SerializeField] Transform spellSpawn;

    private void Awake()
    {

    }

    private void FixedUpdate()
    {

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
}
