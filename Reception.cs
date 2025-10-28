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
    public void BookGuest()
    {
        // enter a room number and guest name, then books the room if it exists and is available.
        // Validates input for room number and guest name and Updates the room's status to 'Occupied'or avialable  and store the guest name.
        Console.Write("Enter room number: ");
        string? roomInput = Console.ReadLine();
        if (!int.TryParse(roomInput, out int roomNumber))
        {
            Console.WriteLine("Invalid room number.");
            return;
        }

        // Find the room
        Room? targetRoom = null;
        for (int i = 0; i < Rooms.Count; i++)
        {
            if (Rooms[i].Room_Number == roomNumber)
            {
                targetRoom = Rooms[i];
                break;
            }
        }

        if (targetRoom == null)
        // room number is invalid
        {
            Console.WriteLine($"Room {roomNumber} does not exist.");
            return;
        }

        if (targetRoom.status == RoomStatus.Occupied)
        {
            Console.WriteLine($"Room {roomNumber} is already occupied.");
            return;
        }

        Console.Write("Enter guest name: ");
        string? guestName = Console.ReadLine();

        if (string.IsNullOrEmpty(guestName))//Guest name must not be null
        {
            Console.WriteLine("Guest name cannot be empty.");
            return;
        }

        //  Book the room
        targetRoom.status = RoomStatus.Occupied;
        targetRoom.GuestName = guestName;
        Console.WriteLine($"Room {roomNumber} booked successfully for {guestName}.");
    }
    
    // Checks out a guest from a room by room number.
    // Sets room status to Available and clears guest name.
    
    
    
    public bool CheckOutGuest(int roomNumber)
    {
        for (int i = 0; i < Rooms.Count; i++)
        {
            Room room = Rooms[i];
            if (room.Room_Number == roomNumber)
            {
                if (room.status == RoomStatus.Occupied)
                {
                    room.status = RoomStatus.Available;
                    room.GuestName = "";
                    return true;
                }
                else
                {
                    return false; // Room is not occupied
                }
            }
        }
        return false; // Room not found
    }

    
    public void CheckOutGuest1()
    {
        Console.Write("Enter room number to check out: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int roomNumber))
        {
            Console.WriteLine("Invalid room number.");
            return;
        }

        if (CheckOutGuest(roomNumber))
        {
            Console.WriteLine($"Guest checked out from room {roomNumber}.");
        }
        else
        {
            Console.WriteLine("Check-out failed. Room may not exist or is not occupied.");
        }
    }

}