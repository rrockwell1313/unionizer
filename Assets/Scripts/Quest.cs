using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
[System.Serializable]
public class Quest : ScriptableObject
{
    public string recipient;
    public string patron;
    [TextArea]
    public string Description;
    // Indicates if quest should be checked when player attempts to leave without completing quest,
    // instead of when they enter
    public bool checkWhenLeave = false;
    bool complete = false;
    public KeyItem item;
    public ReputationCounter repCounter;
    public ReputationCounter negRepCounter;

    public void CompleteQuest()
    {
        complete = true;
        repCounter.Please();
        if (negRepCounter != null)
            negRepCounter.Irritate();
    }

    public bool IsComplete() => complete;
}
