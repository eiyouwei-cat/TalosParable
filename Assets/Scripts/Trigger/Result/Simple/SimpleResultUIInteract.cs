using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(UIInteractItem))]
[RequireComponent(typeof(SimpleConditionInput))]
public class SimpleResultUIInteract : SimpleResult
{
    protected override void FuncSimpleResult(bool satisfied, Action endCall = null)
    {
        UIInteractInfo uiInteract = GetComponent<UIInteractItem>().GetCurUIInteractInfo();
        if (satisfied && uiInteract != null)
        {
            UIManager.Instance.TryAddUIInteract(uiInteract);

            GetComponent<SimpleConditionInput>().SetKeyDown(uiInteract.availableKeyCode);
            GetComponent<SimpleConditionInput>().SetSimpleResults(new List<SimpleResult>() { uiInteract.simpleResult });
            GetComponent<SimpleConditionInput>().CallFuncCondition();
            endCall?.Invoke();
        }
        else
            UIManager.Instance.TryRemoveUIInteract(uiInteract);
        

    }
}
