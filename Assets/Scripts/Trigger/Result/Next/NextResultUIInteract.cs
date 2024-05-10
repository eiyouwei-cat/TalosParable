using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextResultUIInteract : SimpleResult
{
    [SerializeField]
    KeyCode availableKeyCode;
    UIInteract uiInteract = null;
    private void Start()
    {
        InitializeNext();
    }

    void InitializeNext()
    {
        //TODO Trigger List
        resultType = ResultType.Next;
        uiInteract ??= new UIInteract(availableKeyCode, new List<Action> { delegate () { nextTrigger.CheckCondition(); } });
        if (nextTrigger == null)
        {
            Debug.LogError(name + " NULL nextTrigger");
            return;
        }
        if (nextTrigger.gameObject.GetComponent<SimpleConditionInput>() != null)
            return;
        nextTrigger.gameObject.AddComponent<SimpleConditionInput>();
    }
    protected override bool FuncThisResult(bool satisfied)
    {
        if (satisfied)
            UIManager.Instance.TryAddUIInteract(uiInteract);
        else
            UIManager.Instance.TryRemoveUIInteract(uiInteract);
        return true;
    }
    protected override bool FuncNextResult(bool satisfied)
    {
        if (!satisfied)
            return false;
        return nextTrigger.CheckCondition();
    }

    private void OnValidate()
    {
        //TODO Trigger List
        if (nextTrigger != null)
        {
            nextTrigger.isNexted = true;
            nextTrigger.GetComponent<SimpleConditionInput>().KeyCode = availableKeyCode;
        }
    }
}
