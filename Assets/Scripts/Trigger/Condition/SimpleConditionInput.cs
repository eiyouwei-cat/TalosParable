using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConditionInput : SimpleCondition
{
    [HelpBox("Input", HelpBoxType.Info)]
    [SerializeField]
    KeyCode keyCode = KeyCode.None;
    enum InputType
    {
        KeyDown,
        KeyKeep,
    };
    [SerializeField]
    InputType inputType;

    public KeyCode KeyCode
    {
        get
        {
            if (keyCode == KeyCode.None)
                Debug.LogError(name + " NULL keyCode");
            return keyCode;
        }
        set => keyCode = value;
    }
    public void SetKeyDown(KeyCode f_keyCode)
    {
        keyCode = f_keyCode;
        inputType = InputType.KeyDown;
    }
    protected override bool FuncCondition()
    {
        switch (inputType)
        {
            case InputType.KeyDown:
                return Input.GetKeyDown(KeyCode);
            case InputType.KeyKeep:
                return Input.GetKey(KeyCode);
            default:
                return false;
        }
    }

}
