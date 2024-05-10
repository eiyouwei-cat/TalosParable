using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class SimpleResult : MonoBehaviour
{
    public delegate bool Result(bool satisfied);
    public Result result;

    private void Awake()
    {
        result += FuncResult;
    }
    protected abstract bool FuncResult(bool satisfied);

    

}
