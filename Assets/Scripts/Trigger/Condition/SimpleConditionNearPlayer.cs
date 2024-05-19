using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConditionNearPlayer : SimpleConditionNear
{
    [HelpBox("NearPlayer", HelpBoxType.Info)]
    protected override void OnValidate()
    {
        base.OnValidate();
        target = PlayerStateController.Instance.transform;
    }
}
