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
    #region Next
    [HelpBox("Next",HelpBoxType.Info)]
    //[SerializeField]
    //protected TriggerResult nextTrigger;
    protected virtual void Initialize()
    {
        if (!gameObject.activeSelf)
            return;
        //next
        if (resultType == ResultType.Next)
        {
            //if (nextTrigger == null)
            {
                Debug.LogError(name + " NULL next trigger");
                return;
            }
            //TODO NEXT ?!!
            //nextTrigger.isNexted = true;
            //nextTrigger.usedOnce = GetComponent<TriggerResult>().usedOnce;
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
    protected virtual void FuncSimpleResult(bool satisfied = false,Action nextCallback = null)
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
        //TODO true or false ??
        switch (resultType)
        {
            case ResultType.Delay:
                FuncSimpleResult(true);
                StartCoroutine(Delay());
                break;
            case ResultType.Next:
                if(GetComponent<SimpleConditionInput>())
                {
                    ;
                }
                FuncSimpleResult(satisfied);
                //TODO NEXT ?!!
                //FuncSimpleResult(satisfied, delegate () {satisfied = nextTrigger.CallAllResult() && satisfied;});
                break;
            case ResultType.Simple:
                FuncSimpleResult(true);
                break;
            default: break;
        }
    }

}
