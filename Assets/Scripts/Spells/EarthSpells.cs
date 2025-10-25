using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : MonoBehaviour, ISpell
{
    public void SpellAttack()
    {
        Debug.Log("Earth Attack");
    }

    public  void SpellPassif()
    {
        Debug.Log("Earth Passif");
    }

    public  void SpellUlti()
    {
        Debug.Log("Earth Ulti");
    }

    public void AASAS()
    {

    }
  
}
