using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWizardPlace : MonoBehaviour
{
    [SerializeField] int _myID;
    [SerializeField] private SelectionWizardManager _selectManager;
    private Button _selectButton;
    void Start()
    {
        _selectButton = GetComponent<Button>();
        _selectManager = FindFirstObjectByType<SelectionWizardManager>();
        _selectButton.onClick.AddListener(ChangePlaceWizard);
        _selectManager.OnShutDown += ShutDown;
    }

    private void ShutDown()
    {
        _selectButton.onClick.RemoveListener(ChangePlaceWizard);
        _selectManager.OnShutDown -= ShutDown;

    }

    public void ChangePlaceWizard()
    {
        try
        {
            _selectManager.ChangePlaceWizard(_myID);
        }
        catch
        {
            //
        }
    }

    void Update()
    {
        
    }
}
