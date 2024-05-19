using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //[Label("范围球是否可见")]
    //bool visible = true;

    //UI文字
    //摄像头移动
    //玩家锁定
    //[SerializeField]
    //Trigger[] triggers;

    //private void Awake()
    //{
    //    triggers = GetComponentsInChildren<Trigger>();

    //}

    //private void OnValidate()
    //{

    //}

    //[SerializeField]
    //List<StateNode> levelStates = new List<StateNode>();
    //[SerializeField]
    //ObservableValue<StateNode> curState;

    [SerializeField]
    SimpleResult enterResult;
    public void OnEnterLevel()
    {
        //if(curState == null)
        //{
        //curState = new ObservableValue<StateNode>(levelStates[0], OnCurStateChange);
        //}

        enterResult?.result.Invoke(true);
    }

    public void OnLeaveLevel()
    {
        //curState = null;
    }

    //void OnCurStateChange(StateNode oldS,StateNode newS)
    //{
    //
    //}
}
