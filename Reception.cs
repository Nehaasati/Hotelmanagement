namespace App;

using System.Collections.Generic;

public class Reception
{
    
    public List<Room> Rooms;

    public Reception()
    {
        Rooms = new List<Room>();
        // Add 5 sample rooms, all available 
        for (int i = 1; i <= 5; i = i + 1)
        {
            Room room = new Room();
            room.Room_Number = 100 + i;// rrom number are 101,102...105
            room.status = RoomStatus.Available;
            room.GuestName = "";
            Rooms.Add(room);
        }
    }

    // return a list occupied where room status = occupied

    public List<Room> GetOccupiedRooms()
    {
        List<Room> occupied = new List<Room>();
        for (int i = 0; i < Rooms.Count; i = i + 1)
        {
            Room room = Rooms[i];
            if (room.status == RoomStatus.Occupied)
            {
                occupied.Add(room);
            }
        }
        return occupied;
    }
    public List<Room> GetAvailableRooms()
    {
        List<Room> available = new List<Room>();
        for (int i = 0; i < Rooms.Count; i = i + 1)
        {
            Room room = Rooms[i];
            if (room.status == RoomStatus.Available)
            {
                available.Add(room);
            }
        }
        return available;
    }
}