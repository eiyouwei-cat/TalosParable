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
    //Action endedCallback;
    //public Action EndedCallback { get => endedCallback; set => endedCallback = value; }

    
    #region Next
    [HelpBox("Next",HelpBoxType.Info)]
    [SerializeField]
    protected Trigger nextTrigger;
    protected virtual void InitializeNext()
    {
        if (!gameObject.activeSelf)
            return;
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
    }


    #endregion
    #region Delay
    [HelpBox("Delay", HelpBoxType.Info)]
    [SerializeField]
    float delayTime;
    [SerializeField]
    SimpleResult delayResult;
    protected virtual bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
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
        InitializeNext();
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
