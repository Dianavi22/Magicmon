using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/LifeWizard", order = 1)]
//Current life of all wizards
public class LifeWizardData : ScriptableObject
{
    [Header("List of current life of all wizard")]
    public List<int> lifeWizard;
}
