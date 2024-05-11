using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextResult : SimpleResult
{
    private void Awake()
    {
        InitializeNext();
    }

    protected virtual void InitializeNext()
    {
        resultType = ResultType.Next;
    }

    private void OnValidate()
    {
        if (nextTrigger != null)
        {
            nextTrigger.isNexted = true;
        }
    }
}
