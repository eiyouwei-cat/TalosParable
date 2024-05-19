using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMouse : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;//鼠标解锁并显示
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;//鼠标锁定并隐藏
        }
    }
}
