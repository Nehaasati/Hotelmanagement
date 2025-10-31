using App;
using System;
using System.Collections.Generic;

Reception recp = new Reception();

//  Try to LOAD saved rooms
List<Room> loadedRooms = SaveData.LoadRooms();

// If file existed and had data, use it
if (loadedRooms.Count > 0)
{
    recp.Rooms = loadedRooms;
}
//  recp already has 5 default rooms 

bool running = true;

while (running)
{
    Console.WriteLine("\n=== Hotel Room Manager ===");
    Console.WriteLine("1. Show occupied rooms");
    Console.WriteLine("2. Show available rooms");
    Console.WriteLine("3. Book a room");
    Console.WriteLine("4. Check out guest");
    Console.WriteLine("5. Mark room as unavailable");
    Console.WriteLine("6. Make room available");
    Console.WriteLine("7. Exit"); // Add Exit 
    string? input = Console.ReadLine();
    int choice = 0;
    bool p = int.TryParse(input, out choice);

    if (!p)
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            {
                List<Room> occupied = recp.GetOccupiedRooms();
                if (occupied.Count == 0)
                {
                    Console.WriteLine("No guests staying right now.");
                }
                else
                {
                    Console.WriteLine("Currently occupied rooms:");
                    for (int i = 0; i < occupied.Count; i++)
                    {
                        Room r = occupied[i];
                        Console.WriteLine($"Room {r.Room_Number} – Guest: {r.GuestName}");
                    }
                }
                break;
            }

        case 2:
            {
                List<Room> available = recp.GetAvailableRooms();
                if (available.Count == 0)
                {
                    Console.WriteLine("No rooms are currently available.");
                }
                else
                {
                    Console.WriteLine("Available rooms:");
                    for (int i = 0; i < available.Count; i++)
                    {
                        Room r = available[i];
                        Console.WriteLine($"Room {r.Room_Number}");
                    }
                }
                break;
            }
            case 3:
            recp.BookGuest(); // Call the method
            break;
            case 4:
            recp.CheckOutGuest1();
            break;
             case 5:
            recp.MarkRoomUnavailable1();
            break;

            case 6:
            recp.MakeRoomAvailable1();
            break;
            case 7: // EXIT
            // SAVE rooms before quitting
            SaveData.SaveRooms(recp.Rooms);
            Console.WriteLine("Data saved successfully. Goodbye!");
            running = false;
            break;
            default:
            Console.WriteLine("Please choose a valid ");
            break;
    }

    
}

