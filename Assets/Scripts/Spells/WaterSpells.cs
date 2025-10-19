using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpells: SpellBase, ISpell
{
    public  void SpellAttack()
    {
        Debug.Log("Water Attack");
    }

    public  void SpellPassif()
    {
        Debug.Log("Water Passif");
    }

    public  void SpellUlti()
    {
        Debug.Log("Water Ulti");
    }
}
