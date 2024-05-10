using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayResult : SimpleResult
{
    [SerializeField]
    float delayTime;
    [SerializeField]
    DelayResult nextResult;
    //[SerializeField]
    //bool isDelayed;
    protected virtual void FuncDelay()
    {
        throw new System.NotImplementedException();
    }

    protected override bool FuncResult(bool satisfied)
    {
        if (!satisfied)
            return false;
        FuncDelay();
        StartCoroutine(Delay());
        return true;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        nextResult?.FuncResult(true);
        yield break;
    }
    //private void OnValidate()
    //{
    //    if (nextResult != null)
    //    {
    //        nextResult.isDelayed = true;
    //    }
    //}
}
