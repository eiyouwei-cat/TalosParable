using System;
using UnityEngine;
[RequireComponent(typeof(NextResultUIInteract))]
public class SimpleConditionUIInteract : SimpleCondition
{
    public KeyCode availableKeyCode;
    //[SerializeField]
    bool visible = false;
    private void OnBecameVisible()
    {
        visible = true;
        
    }
    private void OnBecameInvisible()
    {
        visible = false;
    }
    protected override bool FuncCondition()
    {
        if (PlayerStateController.Instance.IsBusy())
            return false;
        return visible;
    }
}
