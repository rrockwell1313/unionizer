using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Room { DEVOFFICE, ACCOUNTANT, SECURITY, DATAANALYST, BOSS, HR, CUSTOMERSERVICE, SECRETARY, SALES }

public class MapButtonBehavior : MonoBehaviour
{
    [Header("Reputation Representation")]
    public ReputationDisplay[] displays;
    public Sprite[] smileyFaces;
    public RoomNavigation nav;
    public Room currentRoom;

    // Start is called before the first frame update
private void Start()
    {
        if (nav == null)
        {
            Debug.LogError("RoomNavigation reference is missing!");
            return;
        }

        UpdateButtonReputationDisplays();
    }

    public void UpdateButtonReputationDisplays()
    {
        if (nav == null)
        {
            Debug.LogError("RoomNavigation reference is missing! Can't update button reputation displays.");
            return;
        }
        
        List<Room> connectedRooms = nav.GetConnectedRooms(currentRoom);
        
        // Debug logs connected rooms
        foreach (Room r in connectedRooms)
        {
            Debug.Log($"Connected room: {r}");
        }
        
        foreach (ReputationDisplay d in displays)
        {
            if (d.tracker == null)
            {
                Debug.LogWarning($"ReputationDisplay missing QuestTracker for room {d.room}.");
                continue; // Skip this iteration
            }
            
            if (d.button == null || d.button.image == null)
            {
                Debug.LogWarning($"ReputationDisplay missing Button or Image reference for room {d.room}.");
                continue; // Skip this iteration
            }

            int reputationIndex = (int)d.tracker.reputation;
            
            // Check if the reputation index is within the bounds of the reputationColors array
            if (reputationIndex >= 0 && reputationIndex < smileyFaces.Length)
            {
                d.button.image.sprite = smileyFaces[reputationIndex];
            }
            else
            {
                Debug.LogError($"Invalid reputation index {reputationIndex} for room {d.room}.");
                Debug.Log($"ReputationIndex: {reputationIndex}, smiley faces length: {smileyFaces.Length}");
            }
            
            // If the room represented by this display is not connected, make the button not interactable
            d.button.interactable = connectedRooms.Contains(d.room);
        }
        #region Chandlers Commented out area. Closing for readability. 
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
        #endregion
    }

    [System.Serializable]
    public struct ReputationDisplay
    {
        public Room room;
        public QuestTracker tracker;
        public Button button;
    }
}
