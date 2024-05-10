using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleCondition : MonoBehaviour
{
    public delegate bool Condition();
    public Condition condition;
    private void Awake()
    {
        condition += FuncCondition;
    }
    protected abstract bool FuncCondition();

}