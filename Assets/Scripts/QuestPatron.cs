using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPatron : MonoBehaviour
{
    public Quest quest;
    public QuestLog log;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignMyQuest()
    {
        log.AddQuest(quest);
    }

    public bool HasMyQuest()
    {
        return log.HasQuest(quest);
    }
}
