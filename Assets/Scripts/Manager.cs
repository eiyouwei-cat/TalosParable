using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.Initialize();
        LevelManager.Instance.Initialize();
    }
}
