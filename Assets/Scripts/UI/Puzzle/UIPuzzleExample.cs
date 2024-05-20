using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPuzzleExample : UIPuzzle
{
    public override void CheckPuzzle()
    {
        int r = Random.Range(1, 101);
        puzzleSolved = (r >= 50);
    }
}
