using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemCondition
{
    [SerializeField]
    SerializableDictionary<Item, int> countCondition;
    [SerializeField]
    int priority; // when more than one conditions are satisfied...

    public int GetPriority()
    {
        return priority;
    }
    public bool Satisfied()
    {
        foreach(var it in countCondition.Keys)
        {
            if (!ItemManager.Instance.HaveItem(it, countCondition[it]))
                return false;
        }
        return true;
    }
}
