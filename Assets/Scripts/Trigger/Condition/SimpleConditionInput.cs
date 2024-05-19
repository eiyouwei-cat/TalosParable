using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConditionInput : SimpleCondition
{
    [HelpBox("Input", HelpBoxType.Info)]
    [HideInInspector]
    public int aa;
    [SerializeField]
    [HelpBox("Forced By Last Trigger",HelpBoxType.Warning)]
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
