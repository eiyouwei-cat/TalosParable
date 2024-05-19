using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyCollector : MonoBehaviour
{
    public static List<SimpleResult> busyMoves = new List<SimpleResult>();

    public static void RefreshList(bool added,SimpleResult srm)
    {
        if(added)
            busyMoves.Add(srm);
        else
            busyMoves.Remove(srm);
        if (busyMoves.Count > 0)
        {
            PlayerStateController.Instance.SetState(PlayerStateController.STATE.forceMovingSth);
        }
        else
            PlayerStateController.Instance.SetState(PlayerStateController.STATE.NULL);
    }
}
