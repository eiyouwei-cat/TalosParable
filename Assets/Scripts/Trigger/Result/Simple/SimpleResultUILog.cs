using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultUILog : SimpleResult
{
    [HelpBox("UILog", HelpBoxType.Info)]
    [SerializeField]
    Fadable tarUILog;
    [SerializeField]
    string[] content;
    [SerializeField]
    Color tarColor;
    protected override void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        if (!satisfied)
            return;
        tarUILog.StartFade(true, delegate ()
        {
            BusyCollector.Instance.RefreshList(added: true, this);
        }
        ,
        delegate ()
        {
            tarUILog.GetComponentInChildren<TypeWriter>().SetColor(tarColor);
            tarUILog.GetComponentInChildren<TypeWriter>().StartType(content, endCall);
        }
        );
    }
}
