using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultPartLog : SimpleResult
{
    [HelpBox("PartLog", HelpBoxType.Info)]
    [SerializeField]
    string[] content;
    [SerializeField]
    Color tarColor;
    protected override void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        if (!satisfied)
            return;
        UIManager.Instance.panel_PartLog.StartFade(true, delegate ()
        {
            UIManager.Instance.text_PartLog.SetColor(tarColor);
            UIManager.Instance.text_PartLog.StartType(content, endCall);
            BusyCollector.Instance.RefreshList(added: true, this);
            //PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.renderingText);
        });
    }
}
