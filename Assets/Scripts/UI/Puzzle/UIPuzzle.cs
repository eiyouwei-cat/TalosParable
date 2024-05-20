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
    protected bool puzzleSolved = false;
    
    public virtual void CheckPuzzle()
    {
        puzzleSolved = false;
    }
    public void CallReward()
    {
        if(puzzleReward == null)
        {
            Debug.LogError(name + " 's reward is NULL!");
        }
        puzzleReward.result.Invoke(puzzleSolved);
    }

}
