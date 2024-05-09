using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerResultSetPlayerState : TriggerResult
{
    [SerializeField]
    PlayerStateController.STATE newState;

    protected override void FuncResult()
    {
        PlayerStateController.Instance.SetState(newState);
    }

}
