using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] private List<WizardData> _wizards;
    [SerializeField] private LifeWizardData _lifeWizards;
    [SerializeField] private UltBarWizardData _ultWizards;
    [SerializeField] private ISpell _currentSpell;
    [SerializeField] private GameObject _currentSpellPrefab;
    [SerializeField] private CurrentWizardData _currentWizard;
    [SerializeField] private SpriteRenderer _currentSprite;
    void Start()
    {
        _currentSprite = GetComponentInChildren<SpriteRenderer>();
        ChangeCurrentWizard(0);

    }

    void Update()
    {
        //Temporary 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeCurrentWizard(0);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeCurrentWizard(1);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeCurrentWizard(2);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeCurrentWizard(3);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentSpell.SpellAttack();
        }

    }

    private void ChangeCurrentWizard(int id)
    {
        if (_currentWizard.currentWizardData == _wizards[id] || _lifeWizards.lifeWizard[id] == 0)
        {
            print("Already Select");
            return;
        }

        _currentWizard.currentWizardData = _wizards[id];
        if(_currentSpell != null)
        {
            Destroy(_currentSpellPrefab);
        }
        _currentSpellPrefab = Instantiate(_currentWizard.currentWizardData.wizardSpell, transform);
        _currentSpell = _currentSpellPrefab.GetComponent<ISpell>();
        _currentSprite.material = _currentWizard.currentWizardData.wizardMaterial;
        _currentWizard.currentLife = _lifeWizards.lifeWizard[id];
        _currentWizard.currentUlt = _ultWizards.ultBarWizard[id];
        print(_currentWizard.currentWizardData.nameWizard);
    }
}
