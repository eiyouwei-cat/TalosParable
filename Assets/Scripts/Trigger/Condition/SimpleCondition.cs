using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleCondition : MonoBehaviour
{
    public delegate bool Condition();
    public Condition condition;

    [SerializeField]
    protected int usedThreshold = 1;
    [SerializeField]
    protected int usedCount = 0;
    [SerializeField]
    protected bool usedOnce = true;
    [SerializeField]
    protected SimpleCondition nextSimpleCondition;
    [SerializeField]
    SimpleResult simpleResult;


    protected virtual void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        CallFuncCondtion();
    }
    protected virtual void Initialize()
    {
        condition += FuncCondition;
    }
    protected abstract bool FuncCondition();
    protected bool CallFuncCondtion()
    {
        if(!FuncCondition())
            return false;
        if (nextSimpleCondition == null)
        {
            CallAllResult();
            return true;
        }
        return nextSimpleCondition.CallFuncCondtion();
    }
    public void CallAllResult()
    {
        if (usedCount >= usedThreshold)
        {
            simpleResult.result.Invoke(false);
            return;
        }
        simpleResult.result.Invoke(true);
        if (usedOnce)
        {
            usedCount++;
        }
    }
}
