using App; // so we can use Room and RoomStatus
using System;
using System.Collections.Generic;
using System.IO;

namespace App;
// a class to store all the system data
// Methods here are static in order to call them directly, no need for an object.
public static class SaveData
{
    // Save list of rooms to "rooms.txt"
    public static void SaveRooms(List<Room> rooms)
    {
        using (StreamWriter writer = new StreamWriter("rooms.txt", append: false))// the append is false because when I tried it "True" but all the data duplicate when ever we add a new data.
        {
            foreach (Room room in rooms)
            {
                // Format: RoomNumber,Status,GuestName
                writer.WriteLine($"{room.Room_Number},{room.status},{room.GuestName}");
            }
        }
    }

    // Load rooms from "rooms.txt"
    public static List<Room> LoadRooms()
    {
        List<Room> rooms = new List<Room>();

        // If file doesn't exist, return empty list
        if (!File.Exists("rooms.txt"))
            return rooms;

        using (StreamReader reader = new StreamReader("rooms.txt"))
        {
            string? line;//add ? its show error if string nullable
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                // We expect: RoomNumber, Status, GuestName (3 parts)
                if (parts.Length == 3)
                {
                    int roomNumber = int.Parse(parts[0]);
                    RoomStatus status = (RoomStatus)Enum.Parse(typeof(RoomStatus), parts[1]);//room status
                    string guestName = parts[2];

                    Room room = new Room();
                    room.Room_Number = roomNumber;
                    room.status = status;
                    room.GuestName = guestName;
                    rooms.Add(room);
                }
            }
        }
        return rooms;
    }
     // 
    public static void SaveUsers(List<User> users)
    {
        using (StreamWriter writer = new StreamWriter("users.txt", append: false))
        {
            foreach (User user in users)
            {
                writer.WriteLine($"{user.UserEmail},{user._password}");
            }
        }
    }
    
    
     //Load users from "users.txt"
    public static List<User> LoadUsers()
    {
    List<User> users = new List<User>();

    if (!File.Exists("users.txt"))return users;
    
    // Read "users.txt" file
    using (StreamReader reader = new StreamReader("users.txt"))
    {
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2)// Expect two parts: email and password
            {
                string? email = parts[0];
                string? password = parts[1];
                users.Add(new User(email, password));
            }
        }
    }
    return users;
   }

    
} 
