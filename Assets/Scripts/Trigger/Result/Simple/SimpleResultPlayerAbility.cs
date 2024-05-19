using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultPlayerAbility : SimpleResult
{
    [HelpBox("PlayerAbility",HelpBoxType.Info)]
    [SerializeField]
    bool enable = false;
    protected override void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        if (!satisfied)
            return;
        PlayerStateController.Instance.GetComponent<StarterAssetsInputs>().sprint = enable;
        ThirdPersonController.canJump = ThirdPersonController.canSprint = enable;
        endCall?.Invoke();
    }
}
