using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultSetPlayerState : SimpleResult
{
    [SerializeField]
    PlayerStateController.STATE newState;

    protected override bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
    {
        if (!satisfied)
            return false;
        PlayerStateController.Instance.SetState(newState);
        return true;
    }

}
