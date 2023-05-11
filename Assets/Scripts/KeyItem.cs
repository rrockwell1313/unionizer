using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Item", menuName = "Items/Key Item")]
public class KeyItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
}
