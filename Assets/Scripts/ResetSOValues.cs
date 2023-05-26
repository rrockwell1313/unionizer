using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSOValues : MonoBehaviour
{
    [SerializeField]
    ReputationCounter[] reputations;
    [SerializeField]
    Petition petition;
    // Start is called before the first frame update
    void Start()
    {
        foreach(ReputationCounter rep in reputations)
        {
            //rep.Reset();
        }

        petition.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
