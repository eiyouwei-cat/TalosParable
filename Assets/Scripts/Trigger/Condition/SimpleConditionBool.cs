using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleConditionBool : SimpleCondition
{
    [SerializeField]
    SimpleResultTypeText simpleResultTypeText;

    protected override bool FuncCondition()
    {
        return simpleResultTypeText.Ended;
    }
}
