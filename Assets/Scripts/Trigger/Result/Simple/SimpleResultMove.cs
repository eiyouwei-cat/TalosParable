using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultMove : SimpleResult
{
    [SerializeField]
    Transform moved;
    [SerializeField]
    List<Transform> stations;
    [SerializeField]
    List<float> durations;

    [HelpBox("ReadOnly",HelpBoxType.Warning)]
    [SerializeField]
    int tarId = 0;
    [SerializeField]
    Vector3 speed;
    protected override bool FuncSimpleResult(bool satisfied)
    {
        tarId = 0;
        StartCoroutine(Move());
        return true;
    }
    IEnumerator Move()
    {
        if(!TryCalculateSpeed())
            yield break;
        while (true)
        {
            if (tarId >= stations.Count)
                yield break;
            moved.Translate(speed, Space.World);
            if (Near(moved, stations[tarId]))
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
        speed = (stations[tarId].position - moved.position) / (float)durations[tarId] * Time.deltaTime;
        return true;
    }
    bool Near(Transform a,Transform b)
    {
        if ((a.position - b.position).magnitude <= 0.2f)
            return true;
        return false;
    }
    //private void OnValidate()
    //{
    //    if (stations.Count > speeds.Count)
    //        Debug.LogError(name + " two list' count not equal!");
    //}
}
