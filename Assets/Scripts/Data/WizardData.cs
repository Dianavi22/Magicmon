using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Wizard", order = 1)]
public class WizardData : ScriptableObject
{
    // For menus and wizard presentation
    [Header("Data")]
    public string nameWizard;
    public string descriptionWizard;

    // Moving - add all values statics 
    [Header("Moving")]
    public float speedWizard;
    public float jumpForceWizard;
    public float dashForce;

    // Visual
    [Header("Visual")]
    public Material wizardMaterial; // Temporary 
    public Sprite spriteWizard;
    public GameObject prefabWiard;

    // Scripts
    [Header("Script")]
     public GameObject wizardSpell;

    // Stats
    [Header("Stats")]
    public int maxLife;
    public int maxUltBar;

}
