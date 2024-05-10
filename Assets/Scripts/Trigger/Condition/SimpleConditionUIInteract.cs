using System;
using UnityEngine;
[RequireComponent(typeof(SimpleResultUIInteract))]
public class SimpleConditionUIInteract : SimpleCondition
{
    //[Header("Condition")]
    //[SerializeField]
    public KeyCode availableKeyCode;
    //Func<bool>[] conditionActions;


    //[Header("Result")]
    //Action[] tempResultActions;
    //Action<bool>[] resultActions;
    //[SerializeField]
    //SimpleResult[] simpleResults;
    //UIInteract uiInteract = null;

    [SerializeField]
    bool visible = false;
    //private void Start()
    //{
    //    Initialize();
    //}

    //void Initialize()
    //{
        //    SimpleCondition[] triggerConditions = GetComponents<SimpleCondition>();
        //    conditionActions = new Func<bool>[triggerConditions.Length];
        //    int c = 0;
        //    for (int i = 0; i < triggerConditions.Length; i++)
        //    {
        //        conditionActions[c++] = triggerConditions[i].condition.Invoke;
        //    }

        //    SimpleResult[] triggerResults = GetComponents<SimpleResult>();
        //    tempResultActions = new Action[triggerResults.Length];
        //    c = 0;
        //    for (int i = 0; i < triggerResults.Length; i++)
        //    {
        //        tempResultActions[c++] = triggerResults[i].result.Invoke;
        //    }
        //    resultActions = new Action[c];
        //    for (int i = 0; i < c; i++)
        //    {
        //        resultActions[i] = tempResultActions[i];
        //    }
    //    resultActions = new Action<bool>[simpleResults.Length];
    //    for (int i = 0; i < simpleResults.Length; i++)
    //    {
    //        resultActions[i] = simpleResults[i].result.Invoke;
    //    }
    //    uiInteract ??= new UIInteract(availableKeyCode, resultActions);
    //}

    //private void Update()
    //{
    //    if (visible && CheckCondition())
    //    {
    //        UIManager.Instance.TryAddUIInteract(uiInteract);
    //        return;
    //    }
    //    UIManager.Instance.TryRemoveUIInteract(uiInteract);
    //}
    //bool CheckCondition()
    //{
    //    for (int i = 0; i < conditionActions.Length; i++)
    //    {
    //        if (!conditionActions[i].Invoke())
    //            return false;
    //    }
    //    return true;
    //}
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

    protected override bool FuncCondition()
    {
        if (PlayerStateController.Instance.IsBusy())
            return false;
        
        return visible;
    }
}
