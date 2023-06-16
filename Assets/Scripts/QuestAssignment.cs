using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAssignment : MonoBehaviour
{
    public QuestLog log;
    public Quest quest;
    public KeyItem item;
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        Assign();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Assign()
    {
        log.AddQuest(quest);

        if (item != null && !inventory.IsFull())
        {
            inventory.AddItem(item);
        }
    }
}
