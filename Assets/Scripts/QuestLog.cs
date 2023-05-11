using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestLog", menuName = "Quest System/Quest Log")]
public class QuestLog : ScriptableObject
{
    List<Quest> quests = new List<Quest>();

    public bool HasQuest(Quest checkQuest)
    {
        foreach (Quest q in quests)
        {
            if (q == checkQuest)
                return true;
        }
        return false;
    }

    public void AddQuest(Quest newQuest)
    {

    }

    public Quest[] GetQuests()
    {
        return quests.ToArray();
    }
}
