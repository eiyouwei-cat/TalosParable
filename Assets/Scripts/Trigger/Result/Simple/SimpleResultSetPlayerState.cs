using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultSetPlayerState : SimpleResult
{
    [SerializeField]
    PlayerStateController.STATE newState;

    protected override void FuncSimpleResult(bool satisfied)
    {
        if (!satisfied)
            return;
        PlayerStateController.Instance.SetState(newState);
    }

}
