using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NextResult : SimpleResult
{
    [SerializeField]
    protected Trigger nextTrigger;
    protected abstract override bool FuncResult(bool satisfied);
}
