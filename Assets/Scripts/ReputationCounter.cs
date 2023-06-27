using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Reputation { ANGRY, IRRITATED, NEUTRAL, HAPPY, PLEASED, NONE } //Chandler, I added NONE to the list 

[CreateAssetMenu(fileName = "New Reputation", menuName = "Reputation Counter")]
public class ReputationCounter : ScriptableObject
{
    [SerializeField]
    Reputation reputation;

    public Reputation GetReputation() => reputation;

    public void Please()
    {
        reputation = Reputation.PLEASED;
    }

    public void Irritate()
    {
        if (reputation > 0)
        {
            reputation--;
        }
    }
}
