using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SimpleResult : MonoBehaviour
{
    public delegate bool Result(bool satisfied);
    public Result result;
    [SerializeField]
    protected enum ResultType
    {
        Simple,
        Next,
        Delay
    };
    [SerializeField]
    protected ResultType resultType = ResultType.Simple;
    [SerializeField]
    bool ended = false;
    public bool Ended { get => ended; set => ended = value; }
    Action endedCallback;
    public Action EndedCallback { get => endedCallback; set => endedCallback = value; }

    
    #region Next
    [HelpBox("Next",HelpBoxType.Info)]
    [SerializeField]
    protected Trigger nextTrigger;
    
    protected virtual bool FuncThisResult(bool satisfied)
    {
        throw new NotImplementedException();
    }
    protected virtual bool FuncNextResult(bool satisfied)
    {
        throw new NotImplementedException();
    }
    
    #endregion
    #region Delay
    [HelpBox("Delay", HelpBoxType.Info)]
    [SerializeField]
    float delayTime;
    [SerializeField]
    SimpleResult delayResult;

    

    protected virtual bool FuncSimpleResult(bool satisfied)
    {
        throw new NotImplementedException();
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        delayResult?.FuncCallResult(true);
        yield break;
    }
    #endregion

    private void Awake()
    {
        result += FuncCallResult;
    }
    protected virtual bool FuncCallResult(bool satisfied)
    {
        switch (resultType)
        {
            case ResultType.Delay:
                satisfied = FuncSimpleResult(satisfied);
                EndedCallback?.Invoke();
                if (satisfied)
                    StartCoroutine(Delay());
                return satisfied;
            case ResultType.Next:
                satisfied = FuncThisResult(satisfied) && satisfied;
                return FuncNextResult(satisfied);
            case ResultType.Simple:
                satisfied = FuncSimpleResult(satisfied);
                EndedCallback?.Invoke();
                return satisfied;
            default:return false;
        }
    }

    

}
