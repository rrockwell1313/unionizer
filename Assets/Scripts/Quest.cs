using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string recipient;
    // Indicates if quest should be checked when player attempts to leave without completing quest,
    // instead of when they enter
    public bool checkWhenLeave = false;
    public bool complete = false;
    public KeyItem item;
    public ReputationCounter repCounter;
}
