using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    List<Item> items = new List<Item>();

    public bool HaveItem(Item item,int count)
    {
        foreach(var it in items)
        {
            if(it.Name == item.Name)
                if (it.Count >= count)
                    return true;
        }
        return false;
    }
}
