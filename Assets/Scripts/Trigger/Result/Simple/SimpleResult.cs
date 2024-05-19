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
    protected virtual void Initialize()
    {
        if (!gameObject.activeSelf)
            return;
        //next
        if (resultType == ResultType.Next)
        {
            if (nextTrigger == null)
            {
                Debug.LogError(name + " NULL next trigger");
                return;
            }
            nextTrigger.isNexted = true;
            nextTrigger.usedOnce = GetComponent<Trigger>().usedOnce;
        }
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

    #endregion

    #region Delay
    [HelpBox("Delay", HelpBoxType.Info)]
    [SerializeField]
    protected float delayTime;
    [SerializeField]
    protected SimpleResult delayResult;
    [SerializeField]
    protected bool forceChangeToBusyState = false;
    protected virtual bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
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
    protected virtual bool FuncCallResult(bool satisfied)
    {
        switch (resultType)
        {
            case ResultType.Delay:
                FuncSimpleResult(satisfied, null);
                //EndedCallback?.Invoke();
                if (satisfied)
                    StartCoroutine(Delay());
                return satisfied;
            case ResultType.Next:
                if(satisfied && GetComponent<SimpleConditionInput>())
                {
                    ;
                }
                FuncSimpleResult(satisfied, delegate () {satisfied = nextTrigger.CheckCondition() && satisfied;});
                return satisfied;
            case ResultType.Simple:
                FuncSimpleResult(satisfied, null);
                //EndedCallback?.Invoke();
                return satisfied;
            default:return false;
        }
    }

}
