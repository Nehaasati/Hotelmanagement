using App;
using System;
using System.Collections.Generic;


Reception recp = new Reception();
//bool running = true;
//while (running)
{
    Console.WriteLine("1. Show occupied rooms");

     List<Room> occupied = recp.GetOccupiedRooms();
                if (occupied.Count == 0)
                {
                    Console.WriteLine("No guests staying right now.");
                }
                else
                {
                    Console.WriteLine("Currently occupied rooms:");
                    for (int i = 0; i < occupied.Count; i = i + 1)
                    {
                        Room r = occupied[i];
                        Console.WriteLine($"Room {r.Room_Number} – Guest: {r.GuestName}");
                    }
                    
                }
                
}

