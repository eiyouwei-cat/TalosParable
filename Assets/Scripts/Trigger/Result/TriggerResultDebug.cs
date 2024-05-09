using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerResultDebug : TriggerResult
{
    [SerializeField]
    string debugInfo;
    protected override void FuncResult()
    {
        Debug.Log(name + " "+ debugInfo + " (Triggered)");
    }
}
