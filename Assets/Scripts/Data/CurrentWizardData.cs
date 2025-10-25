using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/CurrentWizard", order = 1)]
public class CurrentWizardData : ScriptableObject
{
    public WizardData currentWizardData;
    public int currentLife;
    public int currentUlt;
}
