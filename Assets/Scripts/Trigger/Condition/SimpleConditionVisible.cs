using System;
using UnityEngine;
[RequireComponent(typeof(SimpleResultUIInteract))]
public class SimpleConditionVisible : SimpleCondition
{
    [HelpBox("Visible", HelpBoxType.Info)]

    [SerializeField]
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
        //if (PlayerStateController.Instance.IsBusy())
        //    return false;
        return visible;
    }

}
