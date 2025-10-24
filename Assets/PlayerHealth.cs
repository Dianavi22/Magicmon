using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _maxHealth;
    public static int CurrentHealth { get; private set; }
    private PlayerData _playerData;
    public event Action<int> OnUpdateLife;

    private void Start()
    {
        _playerData = GetComponent<PlayerData>();
        _playerData.OnGetNewLife += GetNewLife;
    }

    private void OnDisable()
    {
        _playerData.OnGetNewLife -= GetNewLife;
    }

    public void GetNewLife()
    {
        _maxHealth = _playerData.CurrentWizard.currentWizardData.maxLife;
        CurrentHealth = _playerData.CurrentWizard.currentLife;
        print(_maxHealth + " " + CurrentHealth);
    }

    public  bool CheckIsAlive()
    {
        if (CurrentHealth > 0)
        {
            return true;
        }
        return false;
    }

    private void TakeDamage(int damages)
    {
        CurrentHealth -= damages;
        if (!CheckIsAlive())
        {
            CurrentHealth = 0;
        }
        OnUpdateLife.Invoke(CurrentHealth);
    }

    private void TakeHealth(int health)
    {
        CurrentHealth += health;
        if (CurrentHealth > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }
        OnUpdateLife.Invoke(CurrentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeHealth(1);
        }
    }

}
