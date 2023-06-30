using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    public string sceneName;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadRoomScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadRoomScene()
    {
        Debug.Log("clicking");
        SceneManager.LoadScene(sceneName);
    }
}
