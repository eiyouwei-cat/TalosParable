using System;
using UnityEngine;
public class UIInteract
{
    public KeyCode availableKeyCode;
    public Action[] func;

    public UIInteract(KeyCode availableKeyCode, Action[] func)
    {
        this.availableKeyCode = availableKeyCode;
        this.func = func;
    }
}
