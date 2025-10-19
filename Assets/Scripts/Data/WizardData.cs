using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WizardData", order = 1)]
public class WizardData : MonoBehaviour
{
    // For menus and wizard presentation
    public string nameWizard;
    public int descriptionWizard;

    // Moving - add all values statics 
    public float speedWizard;
    public float jumpForceWizard;

    // Visual
    public Material wiardMaterial; // Temporary 
    public Sprite spriteWizard;
    public GameObject prefabWiard;

}
