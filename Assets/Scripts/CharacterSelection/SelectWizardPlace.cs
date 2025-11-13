using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWizardPlace : MonoBehaviour
{
    [SerializeField] int _myID;
    [SerializeField] private SelectionWizardManager _selectManager;
    public WizardData WizardData { get; private set; }
    private Button _selectButton;

    private Image _selectImage;
    void Start()
    {
        _selectImage = GetComponent<Image>();
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

    public void ResetButton()
    {
        WizardData = null;
        _selectImage.material = null;
    }

    public void ChangeDesignButton(WizardData wizardData)
    {
        try
        {
            WizardData = wizardData;
            _selectImage.material = wizardData.wizardMaterial;
        }
        catch
        {
            ResetButton();
        }
       
    }

    void Update()
    {
        
    }
}
