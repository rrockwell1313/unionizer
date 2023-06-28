using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Reputation { ANGRY, IRRITATED, NEUTRAL, HAPPY, PLEASED, NONE }

public enum QuestStatus { NONE, ASSIGNED, COMPLETED, TURNED_IN }

[CreateAssetMenu]
public class QuestTracker : ScriptableObject
{
    public Reputation reputation;
    public QuestStatus questStatus;

    public string[] greetingDialogue;
    public string[] irritatedDialogue;
    public string[] angryDialogue;
    public string[] successDialogue;
    public void Reset()
    {
        reputation = Reputation.NEUTRAL;
        questStatus = QuestStatus.NONE;
    }

    public string[] GetDialogue()
    {
        if (questStatus == QuestStatus.NONE)
        {
            // greet
            questStatus = QuestStatus.ASSIGNED;
            return greetingDialogue;
        }
        else if (questStatus == QuestStatus.ASSIGNED)
        {
            // get angy
            reputation--;
            // if angy, kick out
            if (reputation == Reputation.ANGRY)
            {
                return angryDialogue;
            }
            else
            {
                return irritatedDialogue;
            }
        }
        else if (questStatus == QuestStatus.COMPLETED)
        {
            // sign petition
            questStatus = QuestStatus.TURNED_IN;
            return successDialogue;
        }
        else
        {
            // hey hows it going 
            return new string[] { "Hey, hows it going?" };
        }
    }
}
