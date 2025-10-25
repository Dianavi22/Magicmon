using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] private List<WizardData> _wizards;
    [SerializeField] private LifeWizardData _lifeWizards;
    [SerializeField] private UltBarWizardData _ultWizards;
    private ISpell _currentSpell;
    private GameObject _currentSpellPrefab;
    [SerializeField] private CurrentWizardData _currentWizard;
    private SpriteRenderer _currentSprite;
    private PlayerData _playerData;
    private int _oldID;

    void Start()
    {
        _currentSprite = GetComponentInChildren<SpriteRenderer>();
        _playerData = GetComponent<PlayerData>();
        ChangeCurrentWizard(0);
        _playerData.OnChangeWizard += ChangeWizardAfterGameOver;

    }

    private void OnDisable()
    {
        _playerData.OnChangeWizard -= ChangeWizardAfterGameOver;

    }

    void Update()
    {
        if (DevTool.IsDebugMode)
        {
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

    }

    private void ChangeWizardAfterGameOver()
    {
        ChangeCurrentWizard(GetNewID());
    }
    private int GetNewID()
    {
        _lifeWizards.lifeWizard[_oldID] = 0;
        for (int i = 0; i < _wizards.Count; i++)
        {
            if (_lifeWizards.lifeWizard[i] > 0)
            {
                return i;
            }
        }
        print("GameOver");
        return 3;
    }

    private bool CheckCanTakeWizard(int id)
    {
        if (_lifeWizards.lifeWizard[id] == 0)
        {
            print("NO HEALTH");
            return false;
        }
        if (_currentWizard.currentWizardData == _wizards[id])
        {
            print("Already Select");
            return false;
        }
        return true;

    }

    private void ChangeCurrentWizard(int id)
    {
        if (!CheckCanTakeWizard(id)) return;

        if (_currentWizard.currentWizardData != null)
        {
            _lifeWizards.lifeWizard[_oldID] = _currentWizard.currentLife;
            _ultWizards.ultBarWizard[_oldID] = _currentWizard.currentUlt;
        }

        _oldID = id;
        _currentWizard.currentWizardData = _wizards[id];
        if (_currentSpell != null)
        {
            Destroy(_currentSpellPrefab);
        }
        _currentSpellPrefab = Instantiate(_currentWizard.currentWizardData.wizardSpell, transform);
        _currentSpell = _currentSpellPrefab.GetComponent<ISpell>();
        _currentSprite.material = _currentWizard.currentWizardData.wizardMaterial;
        _currentWizard.currentLife = _lifeWizards.lifeWizard[id];
        _currentWizard.currentUlt = _ultWizards.ultBarWizard[id];
        _playerData.GetNewData(_currentWizard, _currentSpell);
    }

    private void OnDestroy()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        _currentWizard.currentWizardData = null;
    }
}
