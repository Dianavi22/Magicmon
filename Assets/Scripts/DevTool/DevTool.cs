using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTool : MonoBehaviour
{
    [SerializeField] private bool _isDebug;
    public static bool IsDebugMode;
    

    [Header("Health")]
    [SerializeField] LifeWizardData _lifeWizardData;

    [SerializeField] int _healthWish;
    [SerializeField] bool _maxHealth;
    [SerializeField] bool _sameHealth;
    [SerializeField] private List<int> _customHealth;
    [SerializeField, HideInInspector] private List<WizardData> wizardMaxLife;

    [Header("Ulti")]
    [SerializeField] UltBarWizardData _ultWizardData;

    [SerializeField] int _ultWish;
    [SerializeField] bool _maxUlt;
    [SerializeField] bool _sameUlt;
    [SerializeField] private List<int> _customUlt;

    private void Update()
    {
        if (_isDebug) { IsDebugMode = true; }
        else { IsDebugMode = false; }
    }
    private void OnDestroy()
    {

        //Health
        if (_maxHealth) _sameHealth = true;
        if (_sameHealth)
        {
            if (!_maxHealth)
            {
                for (int i = 0; i < _lifeWizardData.lifeWizard.Count; i++)
                {
                    _lifeWizardData.lifeWizard[i] = _healthWish;
                }
            }
            else
            {
                for (int i = 0; i < _lifeWizardData.lifeWizard.Count; i++)
                {
                    _lifeWizardData.lifeWizard[i] = wizardMaxLife[i].maxLife;
                }
            }
        }
        else
        {
            for (int i = 0; i < _lifeWizardData.lifeWizard.Count; i++)
            {
                _lifeWizardData.lifeWizard[i] = _customHealth[i];
            }
        }

        //Ult
        if (_maxUlt) _sameUlt = true;
        if (_sameUlt)
        {
            if (!_maxUlt)
            {
                for (int i = 0; i < _lifeWizardData.lifeWizard.Count; i++)
                {
                    _ultWizardData.ultBarWizard[i] = _ultWish;
                }

            }
            else
            {
                for (int i = 0; i < _ultWizardData.ultBarWizard.Count; i++)
                {
                    _ultWizardData.ultBarWizard[i] = wizardMaxLife[i].maxUltBar;
                }
            }
        }
        else
        {
            for (int i = 0; i < _lifeWizardData.lifeWizard.Count; i++)
            {
                _ultWizardData.ultBarWizard[i] = _customUlt[i];
            }
        }

    }
}
