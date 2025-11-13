using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WizardSelectionButton : MonoBehaviour
{
    [SerializeField] WizardData _myWizard;
    private Button _button;
    [SerializeField] private Image _image;

    [SerializeField] private SelectionWizardManager _selectManager;


    void Start()
    {
        _image = GetComponent<Image>();
        _image.material = _myWizard.wizardMaterial;
        _selectManager = FindFirstObjectByType<SelectionWizardManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SelectWizardInMenu);
        _selectManager.OnShutDown += ShutDown;

    }

    private void ShutDown()
    {
        _button.onClick.RemoveListener(SelectWizardInMenu);
        _selectManager.OnShutDown -= ShutDown;
    }

    private void SelectWizardInMenu()
    {
        _selectManager.SelectWizard(_myWizard);
    }
    void Update()
    {
        
    }
}
