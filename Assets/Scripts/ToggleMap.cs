using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMap : MonoBehaviour
{
    public GameObject officeMap;
    // Start is called before the first frame update
    void Start()
    {
        officeMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMap()
    {
        Debug.Log("Toggling map");
        officeMap.SetActive(true);
    }
}
