using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultUIInteract : SimpleResult
{
    UIInteract uiInteract = null;

    [SerializeField]
    protected Trigger nextTrigger;
    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        //TODO Trigger List
        uiInteract ??= new UIInteract(GetComponent<SimpleConditionUIInteract>().availableKeyCode, new List<Action<bool>> { delegate (bool b) { nextTrigger.CheckCondition(); } });
        if (nextTrigger == null)
        {
            Debug.LogError(name + "NULL nextTrigger");
            return;
        }
        if (nextTrigger.gameObject.GetComponent<SimpleConditionInput>() != null)
            return;
        nextTrigger.gameObject.AddComponent<SimpleConditionInput>();
    }
    protected override bool FuncResult(bool satisfied)
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
    {
        if(nextTrigger != null)
        {
            nextTrigger.isNexted = true;
            nextTrigger.GetComponent<SimpleConditionInput>().KeyCode = GetComponent<SimpleConditionUIInteract>().availableKeyCode;
        }
            //TODO Trigger List
            
    }
}