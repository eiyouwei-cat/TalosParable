using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyCollector : Singleton<BusyCollector>
{
    public List<SimpleResult> busyMoves = new List<SimpleResult>();
    public bool isBusy => busyMoves.Count > 0;
    public void RefreshList(bool added,SimpleResult srm)
    {
        if(added)
            busyMoves.Add(srm);
        else
            busyMoves.Remove(srm);
        if (busyMoves.Count > 0)
            //StartCoroutine(nameof(DelaySetBusyState));
            PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.forceDelay);
        else
            PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.NULL);
    }
}
