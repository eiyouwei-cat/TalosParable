using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class SimpleResultFullLog : SimpleResult
{
    [HelpBox("FullLog", HelpBoxType.Info)]
    [SerializeField]
    Fadable panel_Text;
    [SerializeField]
    TypeWriter text;
    [SerializeField]
    string[] content;
    protected override void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        if (!satisfied)
            return;
        panel_Text.StartFade(true, delegate ()
        {
            text.StartType(content, endCall);
            PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.renderingText);
        });
    }
}
