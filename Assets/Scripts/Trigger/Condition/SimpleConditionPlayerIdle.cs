using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConditionPlayerIdle : SimpleCondition
{
    [HelpBox("PlayerIdle",HelpBoxType.Info)]
    [SerializeField]
    bool busy = false;

    protected override bool FuncCondition()
    {
        return PlayerStateController.Instance.IsBusy() == busy;
    }
}
