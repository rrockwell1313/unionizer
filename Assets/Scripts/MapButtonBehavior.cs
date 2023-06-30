using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Room { DEVOFFICE, ACCOUNTANT, SECURITY, DATAANALYST, BOSS, HR, CUSTOMERSERVICE, SECRETARY, SALES }

public class MapButtonBehavior : MonoBehaviour
{
    [Header("Reputation Representation")]
    public ReputationDisplay[] displays;
    public Color[] reputationColors;
    public RoomNavigation nav;
    public Room currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        UpdateButtonReputationDisplays();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateButtonReputationDisplays()
    {
        //foreach (RoomConnection con in connections)
        //{
        //    bool roomIsConnected = con.RoomIsConnected(currentRoom);
        //    Debug.Log("Room is in connection: " + roomIsConnected + ": " + con.room1 + " " + con.room2);
        //    if (roomIsConnected)
        //    {
        //        Room connected = con.GetConnectedRoom(currentRoom);
        //        Debug.Log("Connected room:" + connected);
        //        connectedRooms.Add(connected);
        //    }
        //}
        List<Room> connectedRooms = nav.GetConnectedRooms(currentRoom);
        foreach (Room r in connectedRooms)
        {
            Debug.Log(r);
        }
        foreach (ReputationDisplay d in displays)
        {
            if (d.tracker is not null)
            {
                d.button.image.color = reputationColors[(int)d.tracker.reputation];
                if (!connectedRooms.Contains(d.room))
                {
                    d.button.interactable = false;
                }
            }            
        }
    }

    [System.Serializable]
    public struct ReputationDisplay
    {
        public Room room;
        public QuestTracker tracker;
        public Button button;
    }
}
