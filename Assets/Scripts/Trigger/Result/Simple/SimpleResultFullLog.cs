using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class SimpleResultFullLog : SimpleResult
{
    [HelpBox("FullLog", HelpBoxType.Info)]
    [SerializeField]
    string[] content;
    [SerializeField]
    Color tarColor;
    protected override void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        if (!satisfied)
            return;
        UIManager.Instance.panel_FullLog.StartFade(true, delegate ()
        {
            BusyCollector.Instance.RefreshList(added: true, this);
            UIManager.Instance.text_FullLog.SetColor(tarColor);
            UIManager.Instance.text_FullLog.StartType(content, endCall);
            //PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.renderingText);
        });
    }
}
