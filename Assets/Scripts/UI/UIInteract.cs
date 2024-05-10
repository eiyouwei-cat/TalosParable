using System;
using System.Collections.Generic;
using UnityEngine;
public class UIInteract
{
    public KeyCode availableKeyCode;
    public List<Action<bool>> func;

    public UIInteract(KeyCode availableKeyCode, List<Action<bool>> func)
    {
        this.availableKeyCode = availableKeyCode;
        this.func = func;
    }
}
