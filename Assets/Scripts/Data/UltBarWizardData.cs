using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/UltBarWizard", order = 1)]
//Current ult of all wizards

public class UltBarWizardData : ScriptableObject
{
    [Header("List of current ult of all wizard")]
    public List<int> ultBarWizard;
}
