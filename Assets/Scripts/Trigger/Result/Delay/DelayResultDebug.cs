using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayResultDebug : DelayResult
{
    [SerializeField]
    string debugInfo;
    protected override void FuncDelay()
    {
        Debug.Log(name + " " + debugInfo + " (Delay Triggered)");
    }
}
