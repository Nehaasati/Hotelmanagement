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
}