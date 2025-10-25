using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public CurrentWizardData CurrentWizard { get; private set; }
    public ISpell CurrentSpell { get; private set; }
    private PlayerHealth _ph;
    private PlayerUlti _pu;
    public event Action OnGetNewLife;
    public event Action OnGetNewUlt;
    public event Action OnChangeWizard;

    private void Start()
    {
        _ph = GetComponent<PlayerHealth>();
        _pu = GetComponent<PlayerUlti>();
        _ph.OnUpdateLife += UpdateLife;
        _pu.OnUpdateUlt += UpdateUlt;
    }

    private void OnDisable()
    {
        _ph.OnUpdateLife -= UpdateLife;
        _pu.OnUpdateUlt -= UpdateUlt;

    }

    private void UpdateLife(int life)
    {
        CurrentWizard.currentLife = life;
        if (!_ph.CheckIsAlive())
        {
            OnChangeWizard.Invoke();
        }
    }

    private void UpdateUlt(int ult)
    {
        CurrentWizard.currentUlt = ult;
    }

    public void GetNewData(CurrentWizardData currentWizard, ISpell currentSpell)
    {
        CurrentWizard = currentWizard;
        CurrentSpell = currentSpell;
        OnGetNewLife.Invoke();
        OnGetNewUlt.Invoke();
    }
  
}
