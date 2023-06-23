using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject
{
    public List<KeyItem> items;

    public bool HasItem(KeyItem item)
    {
        foreach (KeyItem i in items)
        {
            if (i == item)
                return true;
        }

        return false;
    }

    public void AddItem(KeyItem newItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = newItem;
                return;
            }
        }
    }
}
