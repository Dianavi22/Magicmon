using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSpells: SpellBase, ISpell
{
    public  void SpellAttack()
    {
        Debug.Log("Lighting Attack");
    }

    public  void SpellPassif()
    {
        Debug.Log("Lighting Passif");
    }

    public  void SpellUlti()
    {
        Debug.Log("Lighting Ulti");
    }

}
