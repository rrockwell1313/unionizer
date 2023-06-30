using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomNavigation : ScriptableObject
{
    [SerializeField] Connection[] connections;

    public List<Room> GetConnectedRooms(Room checkRoom)
    {
        List<Room> rooms = new List<Room>();

        foreach (Connection con in connections)
        {
            if (con.RoomIsConnected(checkRoom))
            {
                rooms.Add(con.GetConnectedRoom(checkRoom));
            }
        }

        return rooms;
    }
}

[System.Serializable]
public struct Connection
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
