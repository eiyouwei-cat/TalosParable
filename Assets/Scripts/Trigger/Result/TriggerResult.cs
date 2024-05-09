using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class TriggerResult : MonoBehaviour
{
    public delegate void Result();
    public Result result;
    private void Awake()
    {
        result += FuncResult;
    }
    protected abstract void FuncResult();

    public void Call()
    {
        result.Invoke();
    }
}
