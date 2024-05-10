using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleConditionBool : SimpleCondition
{
    [SerializeField]
    SimpleResult simpleResult;
    protected override bool FuncCondition()
    {
        GetComponent<SimpleResult>().EndedCallback = delegate () { simpleResult.Ended = false; };
        return simpleResult.Ended;
    }
}
