using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class SelectionWizardManager : MonoBehaviour
{
    [SerializeField] List<WizardData> _wizardChoosen;
    [SerializeField] List<SelectWizardPlace> _wizardPlaceButton;
    [SerializeField] int _idWizardPlaceID;
    public event Action OnShutDown;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnDisable()
    {
        OnShutDown.Invoke();
    }

    public void ChangePlaceWizard(int id)
    {
        _idWizardPlaceID = id;
    }

    public void SelectWizard(WizardData wizardData)
    {
        if (wizardData == _wizardPlaceButton[_idWizardPlaceID]) return;
        _wizardChoosen[_idWizardPlaceID] = wizardData;
        CheckIfWizardIsTaken();
        _wizardPlaceButton[_idWizardPlaceID].ChangeDesignButton(wizardData);
    }

    private void CheckIfWizardIsTaken()
    {
        for (int i = 0; i < _wizardPlaceButton.Count; i++)
        {
            if (_wizardPlaceButton[i] != null)
            {
                if (_wizardPlaceButton[i].WizardData == _wizardChoosen[_idWizardPlaceID])
                {
                    _wizardPlaceButton[i].ChangeDesignButton(_wizardPlaceButton[_idWizardPlaceID].WizardData);
                }
            }
        }
    }
}
