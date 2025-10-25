using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUlti : MonoBehaviour
{
    private int _maxUlt;
    public static int CurrentUlt { get; private set; }
    private PlayerData _playerData;
    public event Action<int> OnUpdateUlt;


    void Start()
    {
        _playerData = GetComponent<PlayerData>();
        _playerData.OnGetNewUlt += GetNewUlt;

    }
    private void OnDisable()
    {
        _playerData.OnGetNewUlt -= GetNewUlt;
    }

    private void GetNewUlt()
    {
        print("GetNewUlt");

        _maxUlt = _playerData.CurrentWizard.currentWizardData.maxUltBar;
        print(_maxUlt);
        CurrentUlt = _playerData.CurrentWizard.currentUlt;
        print(CurrentUlt);

    }

    private void IncrementUlt(int ult)
    {
        CurrentUlt += ult;
        if (CheckMaxUlt()) CurrentUlt = _maxUlt;
        print(CurrentUlt);
        OnUpdateUlt.Invoke(CurrentUlt);

    }

    private void ReinitUlt()
    {
        CurrentUlt = 0;
        OnUpdateUlt.Invoke(CurrentUlt);

    }

    private bool CheckMaxUlt()
    {
        if (CurrentUlt >= _maxUlt)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (DevTool.IsDebugMode)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                print("IncrementUlt");
                IncrementUlt(1);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                ReinitUlt();
            }
        }
    }
}
