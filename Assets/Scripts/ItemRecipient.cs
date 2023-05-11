using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecipient : MonoBehaviour
{
    public KeyItem itemToReceive;
    public Quest quest;
    public ReputationCounter rep;
    public Inventory inventory;
    public QuestLog log;
    // Start is called before the first frame update
    void Start()
    {
        if (!quest.checkWhenLeave)
            CheckQuest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This is either called when the player opens the scene, unless quest is meant to be checked when they leave
    // if so, this needs to be assigned to button when player leaves
    public void CheckQuest()
    {
        // Check questlog for the quest containing our key item
        if (log.HasQuest(quest))
        {
            Debug.Log("Player has my quest");
            // Check inventory if it contains our key item
            if (inventory.HasItem(itemToReceive))
            {
                // They have the thing I'm looking for
                Debug.Log("They have the item I'm supposed to receive");
                // But should I hate them if they still have it in their inventory when they leave?
                // This should only be called when a player is leaving the office without attempting to give item
                if (quest.checkWhenLeave)
                {
                    rep.Irritate();
                    Debug.Log("They did not give the item, I'm mad");
                }
            }
            else
            {
                // they do not have the item I'm looking for
                // Is this something they should have before they come into my office?
                if (!quest.checkWhenLeave)
                {
                    Debug.Log("They don't have my item and I'm mad");
                    rep.Irritate();
                }
            }
        }
    }
}
