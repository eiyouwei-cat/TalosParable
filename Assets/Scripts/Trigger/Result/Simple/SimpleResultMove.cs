using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultMove : SimpleResult
{
    [HelpBox("Move",HelpBoxType.Info)]
    [SerializeField]
    bool forceChangeToBusyState = true;
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

    protected override bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
    {
        if (!satisfied)
            return false;
        tarId = 0;
        StartCoroutine(Move());
        return true;
    }
    IEnumerator Move()
    {
        if(!TryCalculateSpeed())
            yield break;
        if (forceChangeToBusyState)
            BusyMoveCollector.RefreshList(added: true, this);
        if (tryMove.GetComponent<Camera>())
        {
            MyCamera.Instance.camera.enabled = false;
        }
        while (true)
        {
            if (tarId >= stations.Count)
            {
                BusyMoveCollector.RefreshList(added: false, this);
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
