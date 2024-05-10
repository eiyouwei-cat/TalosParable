using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConditionInput : SimpleCondition
{
    [SerializeField]
    [HelpBox("Forced by Last Trigger")]
    KeyCode keyCode = KeyCode.None;
    enum InputType
    {
        KeyDown,
    };
    [SerializeField]
    InputType inputType;

    public KeyCode KeyCode
    {
        get
        {
            if (keyCode == KeyCode.None)
                Debug.LogError(name + "NULL keyCode");
            return keyCode;
        }
        set => keyCode = value;
    }
    protected override bool FuncCondition()
    {
        switch (inputType)
        {
            case InputType.KeyDown:
                return Input.GetKeyDown(KeyCode);
            default:
                return false;
        }
    }
}
