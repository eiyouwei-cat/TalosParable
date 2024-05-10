using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextResultUIInteract : SimpleResult
{
    UIInteract uiInteract = null;
    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        //TODO Trigger List
        resultType = ResultType.Next;
        uiInteract ??= new UIInteract(GetComponent<SimpleConditionUIInteract>().availableKeyCode, new List<Action> { delegate () { nextTrigger.CheckCondition(); } });
        if (nextTrigger == null)
        {
            Debug.LogError(name + " NULL nextTrigger");
            return;
        }
        if (nextTrigger.gameObject.GetComponent<SimpleConditionInput>() != null)
            return;
        nextTrigger.gameObject.AddComponent<SimpleConditionInput>();
    }
    protected override bool FuncCallResult(bool satisfied)
    {
        if (satisfied)
        {
            UIManager.Instance.TryAddUIInteract(uiInteract);
            return nextTrigger.CheckCondition();
        }
        UIManager.Instance.TryRemoveUIInteract(uiInteract);
        return false;

    }

    private void OnValidate()
    {//TODO Trigger List
        if (nextTrigger != null)
        {
            nextTrigger.isNexted = true;
            nextTrigger.GetComponent<SimpleConditionInput>().KeyCode = GetComponent<SimpleConditionUIInteract>().availableKeyCode;
        }
    }
}
