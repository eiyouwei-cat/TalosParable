using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultUIInteract : SimpleResult
{
    [HelpBox("UIInteract", HelpBoxType.Info)]
    [SerializeField]
    KeyCode availableKeyCode;
    [SerializeField]
    SimpleResult uiInteractResult;
    UIInteractInfo uiInteract = null;
    [SerializeField]
    string interactInfo;

    protected override void Initialize()
    {
        base.Initialize();
        //TODO Trigger List
        uiInteract ??= new UIInteractInfo(availableKeyCode, interactInfo, uiInteractResult);
        
        //if (nextTrigger.gameObject.GetComponent<SimpleConditionInput>() == null)
        //    nextTrigger.gameObject.AddComponent<SimpleConditionInput>();
        //nextTrigger.gameObject.GetComponent<SimpleConditionInput>().KeyCode = availableKeyCode;
    }
    protected override void FuncSimpleResult(bool satisfied = false, Action nextCallback = null)
    {
        if (satisfied)
        {
            UIManager.Instance.TryAddUIInteract(uiInteract);
            //nextCallback();
        }
        else
            UIManager.Instance.TryRemoveUIInteract(uiInteract);
    }
}
