using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractItem : MonoBehaviour
{
    [SerializeField]
    SerializableDictionary<ItemCondition, UIInteractInfo> dic;
    public UIInteractInfo GetCurUIInteractInfo()
    {
        int curPriority = -1;
        ItemCondition curCondition = null;
        foreach (var it in dic.Keys)
        {
            if (!it.Satisfied())
                continue;
            if(it.GetPriority() > curPriority)
            {
                curPriority = it.GetPriority();
                curCondition = it;
            }
        }
        return (curCondition == null) ? null : dic[curCondition].availableKeyCode == KeyCode.None ? null : dic[curCondition];
    }
}

