using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConditionNearPlayer : SimpleConditionNear
{
    protected override void OnValidate()
    {
        base.OnValidate();
        self = transform;
        target = PlayerStateController.Instance.transform;
    }
}
