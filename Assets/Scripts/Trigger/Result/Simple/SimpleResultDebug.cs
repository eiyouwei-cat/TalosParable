using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultDebug : SimpleResult
{
    [HelpBox("Debug",HelpBoxType.Info)]
    [SerializeField]
    string debugInfo;
    protected override bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
    {
        if(!satisfied)
            return false;
        Debug.Log(name + " "+ debugInfo + " (Triggered)");
        return true;
    }
}
