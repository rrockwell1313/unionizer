using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject
{
    public KeyItem[] items;

    public bool HasItem(KeyItem item)
    {
        foreach (KeyItem i in items)
        {
            if (i == item)
                return true;
        }

        return false;
    }
}
