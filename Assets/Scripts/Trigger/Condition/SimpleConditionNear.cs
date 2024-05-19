using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SimpleConditionNear : SimpleCondition
{
    //TODO visible
    [SerializeField]
    bool visible = false;
    [SerializeField]
    GameObject nearSphere;
    [SerializeField]
    Transform self;
    [SerializeField]
    Transform target;
    [SerializeField]
    float nearDistance;

    protected override bool FuncCondition()
    {
        if (self.tag.CompareTo("Player") == 0 || target.tag.CompareTo("Player") == 0)
        {
            if(PlayerStateController.Instance.IsBusy())
                return false;
        }
        return (self.position - target.position).magnitude <= nearDistance;
    }
    private void OnValidate()
    {
        if (!gameObject.activeSelf)
            return;
        nearSphere.transform.parent = null;
        nearSphere.transform.localScale = 2 * nearDistance * Vector3.one;
        nearSphere.transform.parent = transform;
        nearSphere.transform.localPosition = Vector3.zero;
        nearSphere.SetActive(visible);
    }
}
