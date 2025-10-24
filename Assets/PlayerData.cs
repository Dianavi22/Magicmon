using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int LifeWizard { get; private set; }
    public int UltWizard { get; private set; }
    public CurrentWizardData CurrentWizard { get; private set; }
    public ISpell CurrentSpell { get; private set; }
    private PlayerHealth _ph;
    public event Action OnGetNewLife;
    public event Action OnChangeWizard;

    private void Start()
    {
        _ph = GetComponent<PlayerHealth>();
        _ph.OnUpdateLife += UpdateLife;
    }

    private void OnDisable()
    {
        _ph.OnUpdateLife -= UpdateLife;
    }

    private void UpdateLife(int life)
    {
        CurrentWizard.currentLife = life;
        if (!_ph.CheckIsAlive())
        {
            OnChangeWizard.Invoke();
        }
    }

    public void GetNewData(CurrentWizardData currentWizard, ISpell currentSpell)
    {
        CurrentWizard = currentWizard;
        CurrentSpell = currentSpell;
        OnGetNewLife.Invoke();
    }
  
}
