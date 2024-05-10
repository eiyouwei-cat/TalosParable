using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultDebug : SimpleResult
{
    [SerializeField]
    string debugInfo;
    protected override bool FuncSimpleResult(bool satisfied)
    {
        if(!satisfied)
            return false;
        Debug.Log(name + " "+ debugInfo + " (Triggered)");
        return true;
    }
}
