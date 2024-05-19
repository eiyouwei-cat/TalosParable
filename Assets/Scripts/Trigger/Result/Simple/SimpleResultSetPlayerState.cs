using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultSetPlayerState : SimpleResult
{
    [SerializeField]
    PlayerStateController.STATE newState;

    protected override void FuncSimpleResult(bool satisfied, Action endCall = null)
    {
        if (!satisfied)
            return;
        PlayerStateController.Instance.TrySetState(newState);
        endCall?.Invoke();
    }

}
