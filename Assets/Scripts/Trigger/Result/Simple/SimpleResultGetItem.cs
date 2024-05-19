using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultGetItem : SimpleResult
{
    [HelpBox("GetItem",HelpBoxType.Info)]
    [SerializeField]
    Item rewardItem;
    protected override void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        if (!satisfied)
            return;
        ItemManager.Instance.AddItem(rewardItem);
        UIManager.Instance.UIOpenGetItem(rewardItem);
        BusyCollector.Instance.RefreshList(added: true, this);
        //PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.checkItem);
        UIManager.Instance.closeItemCallback = endCall;
    }
}
