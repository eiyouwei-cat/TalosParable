using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : Singleton<PlayerStateController>
{
    public enum STATE
    {
        NULL,
        renderingText,//剧情演出中
        forceDelay,//延迟调用间隙
        checkItem,//获得物体
    }
    [SerializeField]
    ObservableValue<STATE> state;
    [SerializeField]
    AnimationClip clip_wave;
    bool canWave = true;
    public KeyCode key_wave;

    private void Awake()
    {
        state = new ObservableValue<STATE>(STATE.NULL,OnStateChange);
    }
    void Update()
    {
        TryWave();
    }
    void TryWave()
    {
        if (!canWave)
            return;
        if (Input.GetKeyDown(key_wave))
            StartCoroutine(WaveCD());
    }
    IEnumerator WaveCD()
    {
        GetComponent<Animator>().SetTrigger("Wave");
        canWave = false;
        float timer = 0f;
        while (timer < clip_wave.length)
        {
            timer += Time.deltaTime;
            yield return 0;
        }
        canWave = true;
        yield break;
    }
    void OnStateChange(STATE oldV,STATE newV)
    {
        GetComponent<PlayerInput>().enabled = !IsBusy();
    }
    public STATE GetState()
    {
        return state.Value;
    }
    public void TrySetState(STATE newState)
    {
        //Debug.Log("Try set :" + newState.ToString());
        //if (BusyCollector.Instance.isBusy)
        //    return;

        state.Value = newState;
    }
    public bool IsBusy()
    {
        return state.Value == STATE.renderingText || state.Value == STATE.forceDelay;
    }
}
