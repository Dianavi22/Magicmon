using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpells: SpellBase, ISpell
{
    public  void SpellAttack()
    {
        Debug.Log("Fire Attack");
    }

    public  void SpellPassif()
    {
        Debug.Log("Fire Passif");
    }

    public  void SpellUlti()
    {
        Debug.Log("Fire Ulti");
    }

}
