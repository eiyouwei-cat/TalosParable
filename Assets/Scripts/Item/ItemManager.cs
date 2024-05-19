using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    List<Item> items = new List<Item>();

    public bool HaveEnoughItem(Item item,int count)
    {
        foreach(var it in items)
        {
            if(it.Name == item.Name)
                if (it.Count >= count)
                    return true;
        }
        return false;
    }
    public int GetCount(Item item)
    {
        foreach (var it in items)
        {
            if (it.Name == item.Name)
                return it.Count;
        }
        return 0;
    }
    public void AddItem(Item item)
    {
        foreach (var it in items)
        {
            if (it.Name == item.Name)
            {
                it.Count += item.Count;
                return;
            }
        }
        items.Add(item);
    }
}
