using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleResultSetPlayerState))]
public class SimpleResultTypeText : SimpleResult
{
    [SerializeField]
    Fadable panel_Text;
    [SerializeField]
    TypeWriter text;
    [SerializeField]
    string[] content;
    protected override bool FuncResult(bool satisfied)
    {
        if (!satisfied)
            return false;
        panel_Text.StartFade(true, delegate (bool a) {/* Debug.Log(a);*/text.StartType(content); });
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            panel_Text.StartFade(true);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            panel_Text.StartFade(false);
    }
}
