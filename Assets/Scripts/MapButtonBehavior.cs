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
    [Header("Room connection behavior")]
    public Room currentRoom;
    public RoomConnection[] connections;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TEst");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateButtonReputationDisplays()
    {
        List<Room> connectedRooms = new List<Room>();
        foreach (RoomConnection con in connections)
        {
            bool roomIsConnected = con.RoomIsConnected(currentRoom);
            Debug.Log("Room is in connection: " + roomIsConnected + ": " + con.room1 + " " + con.room2);
            if (roomIsConnected)
            {
                Room connected = con.GetConnectedRoom(currentRoom);
                Debug.Log("Connected room:" + connected);
                connectedRooms.Add(connected);
            }
        }
        foreach (Room r in connectedRooms)
            Debug.Log(r);
        foreach (ReputationDisplay d in displays)
        {
            //d.button.image.color = reputationColors[(int)d.counter.GetReputation()];
            //if (!connectedRooms.Contains(d.room))
            //{
            //    d.button.interactable = false;
            //}
        }
    }

    [System.Serializable]
    public struct ReputationDisplay
    {
        public Room room;
        // Replace with new quest tracker
        //public ReputationCounter counter;
        public Button button;
    }

    [System.Serializable]
    public struct RoomConnection
    {
        public Room room1;
        public Room room2;

        public bool isConnected(Room checkRoom, Room current)
        {
            if (room1 == checkRoom && room2 == current)
            {
                return true;
            }
            else if (room1 == current && room2 == checkRoom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RoomIsConnected(Room room)
        {
            if (room1 == room || room2 == room)
                return true;
            else
                return false;
        }

        public Room GetConnectedRoom(Room room)
        {
            if (room1 == room)
                return room2;
            else if (room2 == room)
                return room1;
            else
            {
                Debug.LogError("YOU FUCKED UP!!! YOU TRIED TO GET THE AJOINING ROOM TO A ROOM THAT ISN'T CONNECTED");
                return Room.BOSS;
            }
        }
    }
}
