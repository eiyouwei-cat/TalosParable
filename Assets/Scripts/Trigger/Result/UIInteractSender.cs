using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TriggerCondition))]
public class UIInteractSender : MonoBehaviour
{
    [Header("Condition")]
    [SerializeField]
    KeyCode availableKeyCode;
    Func<bool>[] conditionActions;


    [Header("Result")]
    Action[] tempResultActions;
    Action[] resultActions;
    UIInteract uiInteract = null;

    [SerializeField]
    bool visible = false;
    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        TriggerCondition[] triggerConditions = GetComponents<TriggerCondition>();
        conditionActions = new Func<bool>[triggerConditions.Length];
        int c = 0;
        for (int i = 0; i < triggerConditions.Length; i++)
        {
            conditionActions[c++] = triggerConditions[i].condition.Invoke;
        }

        TriggerResult[] triggerResults = GetComponents<TriggerResult>();
        tempResultActions = new Action[triggerResults.Length];
        c = 0;
        for (int i = 0; i < triggerResults.Length; i++)
        {
            tempResultActions[c++] = triggerResults[i].result.Invoke;
        }
        resultActions = new Action[c];
        for (int i = 0; i < c; i++)
        {
            resultActions[i] = tempResultActions[i];
        }
        uiInteract ??= new UIInteract(availableKeyCode, resultActions);
    }

    private void Update()
    {
        if (visible && CheckCondition())
        {
            UIManager.Instance.TryAddUIInteract(uiInteract);
            return;
        }
        UIManager.Instance.TryRemoveUIInteract(uiInteract);
    }
    bool CheckCondition()
    {
        for (int i = 0; i < conditionActions.Length; i++)
        {
            if (!conditionActions[i].Invoke())
                return false;
        }
        return true;
    }
    private void OnBecameVisible()
    {
        //print("visible!");
        visible = true;
        
    }
    private void OnBecameInvisible()
    {
        visible = false;
        //print("invisible!");
    }

}
