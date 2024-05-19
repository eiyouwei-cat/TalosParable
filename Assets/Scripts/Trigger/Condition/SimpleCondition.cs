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
    List<SimpleResult> simpleResults = new List<SimpleResult>();
    public void SetSimpleResults(List<SimpleResult> simpleResults)
    { this.simpleResults = simpleResults; }

    protected virtual void Awake()
    {
        Initialize();
    }

    
    protected virtual void Initialize()
    {
        condition += FuncCondition;
    }
    protected abstract bool FuncCondition();
    public bool CallFuncCondition()
    {
        if(!FuncCondition())
        {
            SimpleCondition tempLast = this;
            while (tempLast.nextSimpleCondition != null)
            {
                tempLast = tempLast.nextSimpleCondition;
            }
            tempLast.CallNegResult();
            return false;
        }
            
        if (nextSimpleCondition == null)
        {
            CallPosResult();
            return true;
        }
        return nextSimpleCondition.CallFuncCondition();
    }
    void CallNegResult()
    {
        foreach (var simpleResult in simpleResults)
            simpleResult.result.Invoke(false);
    }
    public void CallPosResult()
    {
        if (usedCount >= usedThreshold)
        {
            CallNegResult();
            return;
        }
        foreach (var simpleResult in simpleResults)
            simpleResult.result.Invoke(true);
        if (usedOnce)
        {
            usedCount++;
        }
    }
}
