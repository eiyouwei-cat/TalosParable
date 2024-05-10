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
    protected override bool FuncCallResult(bool satisfied)
    {
        if (!satisfied)
            return false;
        Ended = false;
        panel_Text.StartFade(true, delegate ()
        {
            text.StartType(content, delegate () { Ended = true; });
            PlayerStateController.Instance.SetState(PlayerStateController.STATE.renderingText);
        });
        return true;
    }
}
