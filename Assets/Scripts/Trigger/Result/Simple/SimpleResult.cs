using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SimpleResult : MonoBehaviour
{
    public delegate void Result(bool satisfied);
    public Result result;

    #region Delay
    [HelpBox("Delay", HelpBoxType.Info)]
    [SerializeField]
    protected float delayTime;
    [SerializeField]
    protected SimpleResult delayResult;
    [SerializeField]
    protected bool forceChangeToBusyState = false;
    protected virtual void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        throw new NotImplementedException();
    }
    IEnumerator Delay()
    {
        if (delayResult == null)
            yield break;
        BusyCollector.Instance.RefreshList(added: forceChangeToBusyState, this);
        yield return new WaitForSeconds(delayTime);
        delayResult?.FuncCallResult(true);
        BusyCollector.Instance.RefreshList(added: false, this);
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
        FuncSimpleResult(satisfied,delegate { BusyCollector.Instance.RefreshList(added: false, this); StartCoroutine(Delay()); });
    }

}
