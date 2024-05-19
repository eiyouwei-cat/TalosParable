using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SimpleConditionNear : SimpleCondition
{
    [HelpBox("Near", HelpBoxType.Info)]

    //TODO visible
    [SerializeField]
    bool visible = false;
    [SerializeField]
    GameObject nearSphere;
    [SerializeField]
    protected Transform target;
    [SerializeField]
    float nearDistance;

    

    protected override bool FuncCondition()
    {
        if (transform.tag.CompareTo("Player") == 0 ||  target.tag.CompareTo("Player") == 0)
        {
            if(PlayerStateController.Instance.IsBusy())
                return false;
        }
        return (transform.position - target.position).magnitude <= nearDistance;
    }
    protected virtual void OnValidate()
    {
        if (!gameObject.activeSelf)
            return;
        nearSphere.transform.position = transform.position;
        nearSphere.transform.localScale = 2 * nearDistance * Vector3.one;
        nearSphere.SetActive(visible);
    }
}
