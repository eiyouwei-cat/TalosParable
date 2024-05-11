using System;
using System.Collections.Generic;
using UnityEngine;
public class UIInteract
{
    public KeyCode availableKeyCode;
    public string info;

    public UIInteract(KeyCode availableKeyCode, string info)
    {
        this.availableKeyCode = availableKeyCode;
        this.info = info;
    }
}
