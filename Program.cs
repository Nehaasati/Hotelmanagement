using App;
using System;
using System.Collections.Generic;

Reception recp = new Reception();
bool running = true;

while (running)
{
    Console.WriteLine("\n=== Hotel Room Manager ===");
    Console.WriteLine("1. Show occupied rooms");
    Console.WriteLine("2. Show available rooms");
    Console.WriteLine("3. Exit");

    string? input = Console.ReadLine();
    int choice = 0;
    bool parsed = int.TryParse(input, out choice);

    if (!parsed)
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

        

        default:
            Console.WriteLine("Please choose a valid ");
            break;
    }

    
}

