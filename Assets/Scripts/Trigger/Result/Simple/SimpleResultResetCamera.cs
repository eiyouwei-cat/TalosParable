using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class SimpleResultResetCamera : SimpleResult
{
    [HelpBox("ResetCamera", HelpBoxType.Info)]
    [SerializeField]
    float resetTime = 2f;
    [SerializeField]
    float resetTimer;
    [SerializeField]
    Vector3 posStart = new Vector3(0f, 1.6f, 2f);
    [SerializeField]
    Vector3 posEnd = new Vector3(0f, 1.6f, 4f);
    protected override bool FuncSimpleResult(bool satisfied, Action nextCallback = null)
    {
        if(!satisfied)
            return false;
            MyCamera.Instance.camera.enabled = true;
        //Camera.main.transform.position = MyCamera.Instance.camera.m_Follow.parent.position + posStart;
        //Camera.main.transform.rotation = new Quaternion(0f,180f,0f,0f);
        //StartCoroutine(ResetZ());
        return true;
    }

    //IEnumerator ResetZ()
    //{
    //    resetTimer = 0f;
    //    while(resetTimer < resetTime)
    //    {
    //        resetTimer += Time.deltaTime;
    //        Camera.main.transform.Translate(Time.deltaTime/resetTime * (posEnd - posStart), Space.World);
            
    //        yield return 0;
    //    }
    //}

}