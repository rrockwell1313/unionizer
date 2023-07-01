using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Reputation { ANGRY, IRRITATED, NEUTRAL, HAPPY, PLEASED, NONE }

public enum QuestStatus { NONE, ASSIGNED, COMPLETED, TURNED_IN }

[CreateAssetMenu]
public class QuestTracker : ScriptableObject
{
    [HideInInspector] public Reputation reputation;
    public Reputation startRep = Reputation.NEUTRAL;
    public QuestStatus questStatus;

    [TextArea]
    public string[] greetingDialogue;
    [TextArea]
    public string[] irritatedDialogue;
    [TextArea]
    public string[] angryDialogue;
    [TextArea]
    public string[] successDialogue;
    public void Reset()
    {
        reputation = startRep;
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
