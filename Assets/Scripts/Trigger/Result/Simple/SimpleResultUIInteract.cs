using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultUIInteract : SimpleResult
{
    [HelpBox("UIInteract", HelpBoxType.Info)]
    [SerializeField]
    KeyCode availableKeyCode;
    UIInteractInfo uiInteract = null;
    [SerializeField]
    string interactInfo;

    protected override void Initialize()
    {
        base.Initialize();
        //TODO Trigger List
        uiInteract ??= new UIInteractInfo(availableKeyCode, interactInfo);
        
        if (nextTrigger.gameObject.GetComponent<SimpleConditionInput>() == null)
            nextTrigger.gameObject.AddComponent<SimpleConditionInput>();
        nextTrigger.gameObject.GetComponent<SimpleConditionInput>().KeyCode = availableKeyCode;
    }
    protected override bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
    {
        if (satisfied)
        {
            UIManager.Instance.TryAddUIInteract(uiInteract);
            nextCallback();
        }
        else
            UIManager.Instance.TryRemoveUIInteract(uiInteract);
        return true;
    }
}
