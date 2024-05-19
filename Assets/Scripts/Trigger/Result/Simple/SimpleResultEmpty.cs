using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultEmpty : SimpleResult
{
    protected override void FuncSimpleResult(bool satisfied, Action nextCallback = null)
    {
        return;
    }
}
