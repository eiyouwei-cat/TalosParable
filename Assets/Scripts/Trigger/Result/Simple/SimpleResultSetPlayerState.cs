using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultSetPlayerState : SimpleResult
{
    [SerializeField]
    PlayerStateController.STATE newState;

    protected override bool FuncCallResult(bool satisfied)
    {
        if (!satisfied)
            return false;
        PlayerStateController.Instance.SetState(newState);
        return true;
    }

}
