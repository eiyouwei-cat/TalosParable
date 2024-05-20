using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    SimpleResult enterResult;
    [SerializeField]
    AudioClip levelClip;
    public void OnEnterLevel()
    {
        AudioManager.Instance.PlayOneShot(levelClip);

        enterResult?.result.Invoke(true);
    }

    public void OnLeaveLevel()
    {
        AudioManager.Instance.Stop(levelClip);
    }
}
