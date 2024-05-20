using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleResultShowPuzzle : SimpleResult
{
    [HelpBox("ShowPuzzle", HelpBoxType.Info)]
    [SerializeField]
    UIPuzzle puzzle;
    protected override void FuncSimpleResult(bool satisfied = false, Action endCall = null)
    {
        if (!satisfied)
            return;
        
        BusyCollector.Instance.RefreshList(added: true, this);
        UIManager.Instance.puzzleCallback = endCall;
        UIManager.Instance.curPuzzle = puzzle;
        UIManager.Instance.UIShowPuzzle(puzzle.gameObject);
    }
}
