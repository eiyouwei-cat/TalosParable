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
        if(!rewardItem.isTrigger)
        {
            UIManager.Instance.UIOpenGetItem(rewardItem);
            BusyCollector.Instance.RefreshList(added: true, this);
            UIManager.Instance.closeItemCallback = endCall;
        }
        else
        {
            ItemManager.Instance.AddItem(rewardItem);
            endCall?.Invoke();
        }
    }
}
