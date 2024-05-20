using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LogContent
{
    public string content;
    public AudioClip audioClip;
}

public class SimpleResultUILog : SimpleResult
{
    [HelpBox("UILog", HelpBoxType.Info)]
    [SerializeField]
    Fadable tarUILog;
    [SerializeField]
    List<LogContent> logs;
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
            tarUILog.GetComponentInChildren<TypeWriter>().StartType(logs, endCall);
        }
        );
    }
}
