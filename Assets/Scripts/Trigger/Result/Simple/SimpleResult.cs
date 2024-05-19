using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SimpleResult : MonoBehaviour
{
    public delegate void Result(bool satisfied);
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
    
    protected virtual void Initialize()
    {
        if (!gameObject.activeSelf)
            return;
        ////delay
        if (resultType == ResultType.Delay)
        {
            forceChangeToBusyState = true;
        }

    }
    private void OnValidate()
    {
        Initialize();
    }

    #region Delay
    [HelpBox("Delay", HelpBoxType.Info)]
    [SerializeField]
    protected float delayTime;
    [SerializeField]
    protected SimpleResult delayResult;
    [SerializeField]
    protected bool forceChangeToBusyState = false;
    protected virtual void FuncSimpleResult(bool satisfied = false)
    {
        throw new NotImplementedException();
    }
    IEnumerator Delay()
    {
        BusyCollector.RefreshList(added: true, this);
        yield return new WaitForSeconds(delayTime);
        delayResult?.FuncCallResult(true);
        BusyCollector.RefreshList(added: false, this);
        yield break;
    }
    #endregion

    protected virtual void Awake()
    {
        result += FuncCallResult;
        //Initialize();
    }
    protected virtual void FuncCallResult(bool satisfied)
    {
        switch (resultType)
        {
            case ResultType.Delay:
                FuncSimpleResult(satisfied);
                StartCoroutine(Delay());
                break;
            case ResultType.Simple:
                FuncSimpleResult(satisfied);
                break;
            default: break;
        }
    }

}
