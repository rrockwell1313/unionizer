using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSOValues : MonoBehaviour
{
    //[SerializeField]
    //ReputationCounter[] reputations;
    [SerializeField]
    QuestTracker[] questTrackers;
    // Start is called before the first frame update
    void Start()
    {
        foreach (QuestTracker tracker in questTrackers)
        {
            tracker.Reset();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
