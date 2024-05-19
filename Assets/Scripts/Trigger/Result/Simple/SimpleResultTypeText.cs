using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class SimpleResultTypeText : SimpleResult
{
    [HelpBox("Type",HelpBoxType.Info)]
    [SerializeField]
    Fadable panel_Text;
    [SerializeField]
    TypeWriter text;
    [SerializeField]
    string[] content;
    protected override bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
    {
        if (!satisfied)
            return false;
        panel_Text.StartFade(true, delegate ()
        {
            text.StartType(content, nextCallback);
            PlayerStateController.Instance.SetState(PlayerStateController.STATE.renderingText);
        });
        return true;
    }
}
