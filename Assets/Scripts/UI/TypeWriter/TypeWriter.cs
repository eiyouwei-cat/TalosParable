using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : Singleton<TypeWriter>
{
    [SerializeField]
    float typeCD = 0.03f;
    string mShownText;
    string[] targetStrings;
    int curLine;
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TrySkipType(
                delegate () 
                {
                    transform.parent.GetComponent<Fadable>().StartFade(false, delegate (bool a) { PlayerStateController.Instance.SetState(PlayerStateController.STATE.NULL); });
                }) ;
        }
    }
    public void StartType(string[] fTargetStrings)
    {
        targetStrings = fTargetStrings;
        curLine = 0;
        if (targetStrings != null && targetStrings.Length != 0)
            StartCoroutine(TypeLine(targetStrings[curLine]));
    }
    public void TrySkipType(Action callback = null)
    {
        StopAllCoroutines();
        if (targetStrings[curLine].Length != mShownText.Length)
        {
            GetComponent<Text>().text = mShownText = targetStrings[curLine];
        }
        else
        {
            TypeNextLine(callback);
        }
    }
    void TypeNextLine(Action callback = null)
    {
        curLine++;
        if(curLine == targetStrings.Length)
        {
            callback?.Invoke();
            return;
        }
        StartCoroutine(TypeLine(targetStrings[curLine]));
    }
    public IEnumerator TypeLine(string fTargetString)
    {
        
        mShownText = "";
        
        int mCurPos = 0;
        while (true)
        {
            if (fTargetString.Length == mCurPos)
                yield break;
            mShownText += fTargetString.Substring(mCurPos, 1);
            GetComponent<Text>().text = mShownText + "<color=#13171800>" + fTargetString.Substring(mCurPos + 1) + "</color>";
            mCurPos++;
            yield return new WaitForSeconds(typeCD);
        }   
    }
}
