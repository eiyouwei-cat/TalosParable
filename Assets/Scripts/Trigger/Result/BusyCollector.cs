using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyCollector : MonoBehaviour
{
    public static List<SimpleResult> busyMoves = new List<SimpleResult>();
    public static bool isBusy => busyMoves.Count > 0;
    public static void RefreshList(bool added,SimpleResult srm)
    {
        if(added)
            busyMoves.Add(srm);
        else
            busyMoves.Remove(srm);
        if (busyMoves.Count > 0)
        {
            PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.forceMovingSth);
        }
        else
            PlayerStateController.Instance.TrySetState(PlayerStateController.STATE.NULL);
    }
}
