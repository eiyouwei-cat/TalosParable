using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultUIInteract : SimpleResult
{
    [HelpBox("UIInteract", HelpBoxType.Info)]
    [SerializeField]
    KeyCode availableKeyCode;
    UIInteract uiInteract = null;
    [SerializeField]
    string interactInfo;

    protected override void InitializeNext()
    {
        base.InitializeNext();
        //TODO Trigger List
        uiInteract ??= new UIInteract(availableKeyCode, interactInfo);
        if (nextTrigger == null)
        {
            Debug.LogError(name + " NULL nextTrigger");
            return;
        }
        if (nextTrigger.gameObject.GetComponent<SimpleConditionInput>() != null)
            return;
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
