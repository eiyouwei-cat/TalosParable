using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleResultTypeText : SimpleResult
{
    [HelpBox("Type",HelpBoxType.Info)]
    [SerializeField]
    Fadable panel_Text;
    [SerializeField]
    TypeWriter text;
    [SerializeField]
    string[] content;
    protected override bool FuncCallResult(bool satisfied)
    {
        if (!satisfied)
            return false;
        panel_Text.StartFade(true, delegate (bool a) {text.StartType(content); PlayerStateController.Instance.SetState(PlayerStateController.STATE.renderingText); });
        return true;
    }
}
