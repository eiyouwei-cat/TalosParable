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
    int curLine;

    Action m_callback_added;
    [SerializeField]
    List<LogContent> m_logs;
    [SerializeField]
    AudioClip curAudioClip;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TrySkipType(delegate ()
            {
                transform.parent.GetComponent<Fadable>().StartFade(false,null,m_callback_added);
            });
        }
    }
    public void StartType(List<LogContent> f_logs, Action added_callback = null)
    {
        m_logs = f_logs;
        m_callback_added = added_callback;
        curLine = 0;
        if (m_logs.Count >= 0)
            StartCoroutine(TypeLine());
    }
    public void TrySkipType(Action callback = null)
    {
        StopAllCoroutines();
        if (m_logs[curLine].content.Length != mShownText.Length)
        {
            GetComponent<Text>().text = mShownText = m_logs[curLine].content;
        }
        else
        {
            TypeNextLine(callback);
        }
    }
    void TypeNextLine(Action callback = null)
    {
        curLine++;
        if(curLine == m_logs.Count)
        {
            callback?.Invoke();
            return;
        }
        StartCoroutine(TypeLine());
        
    }
    public IEnumerator TypeLine()
    {
        AudioManager.Instance.Stop(curAudioClip);
        curAudioClip = m_logs[curLine].audioClip;
        AudioManager.Instance.PlayOneShot(curAudioClip);

        string targetString = m_logs[curLine].content;

        mShownText = "";
        
        int mCurPos = 0;
        while (true)
        {
            if (targetString.Length == mCurPos)
                yield break;
            mShownText += targetString.Substring(mCurPos, 1);
            GetComponent<Text>().text = mShownText + "<color=#13171800>" + targetString.Substring(mCurPos + 1) + "</color>";
            mCurPos++;
            yield return new WaitForSeconds(typeCD);
        }   
    }
    public void SetColor(Color f_color)
    {
        GetComponent<Text>().color = f_color;
    }
}
