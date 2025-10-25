using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectionWizardManager : MonoBehaviour
{
    [SerializeField] List<WizardData> _wizardDatas;
    [SerializeField] List<WizardData> _wizardChoosen;
    [SerializeField] int _idWizardPlaceID;
    public event Action<WizardData> OnWizardPlaceChanged;
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

    private void SelectWizard(int idWizardData)
    {
        _wizardChoosen[_idWizardPlaceID] = _wizardDatas[idWizardData];
    }
}
