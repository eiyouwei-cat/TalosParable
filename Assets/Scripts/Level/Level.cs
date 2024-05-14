using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Label("范围球是否可见")]
    bool visible = true;

    //UI文字
    //摄像头移动
    //玩家锁定
    [SerializeField]
    Trigger[] triggers;

    private void Awake()
    {
        triggers = GetComponentsInChildren<Trigger>();
        
    }

    private void OnValidate()
    {
        
    }
}
