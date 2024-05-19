using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultMove : SimpleResult
{
    [HelpBox("Move", HelpBoxType.Info)]
    [SerializeField]
    bool visible = true;
    [SerializeField]
    Transform tryMove;
    [SerializeField]
    List<Transform> stations;
    [SerializeField]
    List<float> durations;

    [HelpBox("ReadOnly",HelpBoxType.Warning)]
    [SerializeField]
    int tarId = 0;
    [SerializeField]
    float speed;

    protected virtual void OnValidate()
    {
        foreach (Transform t in stations)
            t.gameObject.SetActive(true);
    }
    protected override void Awake()
    {
        base.Awake();
        if (tryMove.GetComponent<Camera>())
        {
            if(delayResult == null)
            {
                Debug.LogError(name + "NULL delay result");
            }
            else if(!delayResult.GetComponent<SimpleResultResetCamera>())
            {
                Debug.LogError(name + "delay not reset camera");
            }
        }
    }
    protected override void FuncSimpleResult(bool satisfied, Action endCall = null)
    {
        if (!satisfied)
            return;
        tarId = 0;
        StartCoroutine(Move(endCall));
    }
    IEnumerator Move(Action endCall = null)
    {
        if(!TryCalculateSpeed())
            yield break;
        if (forceChangeToBusyState)
            BusyCollector.Instance.RefreshList(added: true, this);
        if (tryMove.GetComponent<Camera>())
        {
            MyCamera.Instance.camera.enabled = false;
        }
        while (true)
        {
            if (tarId >= stations.Count)
            {
                BusyCollector.Instance.RefreshList(added: false, this);
                endCall();
                yield break;
            }
            tryMove.Translate(speed * Vector3.Normalize(stations[tarId].position - tryMove.position), Space.World);
            if (Near(tryMove, stations[tarId]))
            {
                tarId++;
                TryCalculateSpeed();
            }
            yield return 0;
        }
    }
    bool TryCalculateSpeed()
    {
        if (tarId >= stations.Count)
            return false;
        speed = ((stations[tarId].position - tryMove.position) / (float)durations[tarId] * Time.deltaTime).magnitude;
        return true;
    }
    bool Near(Transform a,Transform b)
    {
        if ((a.position - b.position).magnitude <= 0.2f)
            return true;
        return false;
    }
}
