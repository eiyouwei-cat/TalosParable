using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class UIPuzzle : MonoBehaviour
{
    [SerializeField]
    SimpleResult puzzleReward;
    [SerializeField]
    bool puzzleSolved = false;
    
    public bool CheckPuzzle()
    {
        puzzleReward.result.Invoke(puzzleSolved);
        return puzzleSolved;
    }
}
