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
    #region Next
    [HelpBox("Next",HelpBoxType.Info)]
    [SerializeField]
    protected Trigger nextTrigger;
    private bool ended = false;
    public bool Ended { get => ended; set => ended = value; }
    protected virtual bool FuncThisResult(bool satisfied)
    {
        throw new System.NotImplementedException();
    }
    protected virtual bool FuncNextResult(bool satisfied)
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
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
                if (satisfied)
                    StartCoroutine(Delay());
                return satisfied;
            case ResultType.Next:
                satisfied = FuncThisResult(satisfied) && satisfied;
                return FuncNextResult(satisfied);
            case ResultType.Simple:
                satisfied = FuncSimpleResult(satisfied);
                return satisfied;
            default:return false;
        }
    }

    

}
