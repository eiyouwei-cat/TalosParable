using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyMoveCollector : MonoBehaviour
{
    public static List<SimpleResultMove> busyMoves = new List<SimpleResultMove>();

    public static void RefreshList(bool added,SimpleResultMove srm)
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
