using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestLog", menuName = "Quest System/Quest Log")]
public class QuestLog : ScriptableObject
{
    [SerializeField]
    List<Quest> quests = new List<Quest>();

    public bool HasQuest(Quest checkQuest)
    {
        foreach (Quest q in quests)
        {
            if (q == checkQuest && !q.IsComplete())
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

    public string[] GetPetitionNames()
    {
        List<string> signatures = new List<string>();
        foreach (Quest q in quests)
        {
            if (q.IsComplete())
            {
                signatures.Add(q.patron);
            }
        }

        return signatures.ToArray();
    }

    public int GetPetitionCount()
    {
        string[] signatures = GetPetitionNames();
        return signatures.Length;
    }
}
