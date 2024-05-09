using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    List<Level> levels = new List<Level>();
    private void Awake()
    {
        for (int i = 0;i< transform.childCount;i++)
        {
            levels.Add(transform.GetChild(i).GetComponent<Level>());
        }
    }
}
