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
    protected virtual bool FuncThisResult(bool satisfied)
    {
        throw new System.NotImplementedException();
    }
    public virtual bool FuncNextResult(bool satisfied)
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
    protected virtual bool FuncResult(bool satisfied)
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
                satisfied = FuncResult(satisfied) && satisfied;
                if (satisfied)
                    StartCoroutine(Delay());
                return satisfied;
            default:
                return false;
        }
    }

    

}
