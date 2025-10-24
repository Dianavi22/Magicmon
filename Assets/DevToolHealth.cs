using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevToolHealth : MonoBehaviour
{
    [SerializeField] LifeWizardData _lifeWizardData;
    [SerializeField] int _healthWish;
    [SerializeField] bool _maxHealth;
    [SerializeField] bool _sameHealth;
    [SerializeField] private List<int> _customHealth;

    [SerializeField, HideInInspector] private List<WizardData> wizardMaxLife;
    private void OnDestroy()
    {
        if(_maxHealth) _sameHealth = true;
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


    }
}
