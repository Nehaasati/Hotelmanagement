using App;
using System;
using System.Collections.Generic;

Reception recp = new Reception();

//  Try to LOAD saved rooms

List<Room> loadedRooms = SaveData.LoadRooms();
//load user
List<User> allUsers = SaveData.LoadUsers();

// If file existed and had data, use it
if (loadedRooms.Count > 0)
{
    recp.Rooms = loadedRooms;
}
User? currentUser = null;


while (true)
{
    // Registration
    Console.WriteLine(" Hotel Management System");
    Console.WriteLine("1. Register a new account");
    Console.WriteLine("2. Login to existing account");
    Console.WriteLine("3. exit");
    Console.Write("Choose an option: ");
    // choose option
    string? choiceInput = Console.ReadLine();
    if (!int.TryParse(choiceInput, out int choice))
    {
        Console.WriteLine("Invalid input.");
        continue;
    }
     // for exit user choose option 3
    if (choice == 3)
    {
        SaveData.SaveRooms(recp.Rooms);// data save in room
        Console.WriteLine("Goodbye!");
        break;
    }

    // REGISTRATION 
    if (choice == 1)
    {
        Console.Write("Enter your email: ");//enter email id
        string? email = Console.ReadLine();
        Console.Write("Enter a password: ");//enter password
        string? password = Console.ReadLine();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))// if email and password empty
        {
            Console.WriteLine(" Email and password cannot be empty.");
            continue;
        }

        // Check if email already exists
        bool emailExists = false;
        foreach (User u in allUsers)
        {
            if (u.UserEmail == email)
            {
                emailExists = true;
                break;
            }
        }

        if (emailExists)
        {
            Console.WriteLine(" This email is already registered.");
        }
        else
        {
            allUsers.Add(new User(email, password));
            SaveData.SaveUsers(allUsers);
            Console.WriteLine(" Registration successful! You can now log in.");
        }
        continue; // Go back 
    }
    //  LOGIN as user
    if (choice == 2)
    {
        Console.Write("Email: ");
        string? inputEmail = Console.ReadLine();
        Console.Write("Password: ");
        string? inputPass = Console.ReadLine();

        if (string.IsNullOrEmpty(inputEmail) || string.IsNullOrEmpty(inputPass))//check email and password are not empty
        {
            Console.WriteLine(" Fields cannot be empty.");
            continue;
        }
        // Attempt to find a matching user account
        User? foundUser = null;
        foreach (User u in allUsers)
        {
            if (u.UserEmail == inputEmail && u._password == inputPass)// check useremail and password with stor data
            {
                foundUser = u;
                break;
            }
        }
        //check if-else stmt user are register or not
        if (foundUser == null)
        {
            Console.WriteLine("Invalid email or password.");
            continue;
        }

        currentUser = foundUser;
        Console.WriteLine($"\n Welcome, {currentUser.UserEmail}!");


        //after login user able to see option for room availablity



        bool running = true;
         // show all option
        while (running)
        {
            Console.WriteLine("\n=== Hotel Room Manager ===");
            Console.WriteLine("1. Show occupied rooms");// show occupied room
            Console.WriteLine("2. Show available rooms");//show available room
            Console.WriteLine("3. Book a room");  // from this otption you book room
            Console.WriteLine("4. Check out guest");  // for checkout
            Console.WriteLine("5. Mark room as unavailable");// for this option we make room unaviblable for maintance
            Console.WriteLine("6. Make room available");// again unavailbale room become available
            Console.WriteLine("7. Exit"); 
            string? input = Console.ReadLine();
            
            if (!int.TryParse(input, out int roomChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (roomChoice)
            {
                case 1:
                    {
                        List<Room> occupied = recp.GetOccupiedRooms();
                        if (occupied.Count == 0)  //check occuiped room is empty or not
                        {
                            Console.WriteLine("No guests staying right now.");
                        }
                        else
                        {
                            Console.WriteLine("Currently occupied rooms:");
                            for (int i = 0; i < occupied.Count; i++)
                            {
                                Room r = occupied[i];
                                Console.WriteLine($"Room {r.Room_Number} – Guest: {r.GuestName}");// show guest detail name and roomnumber
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
                            for (int i = 0; i < available.Count; i++)//print the availble room
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
                    recp.CheckOutGuest1();//chekout guest
                    break;
                case 5:
                    recp.MarkRoomUnavailable1();// make room unavailable
                    break;

                case 6:
                    recp.MakeRoomAvailable1();// make room again available
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
            // If user logged out, go back to login screen
            if (currentUser == null && running)
            {
                // Reload users in case new accounts were added (optional)
                allUsers = SaveData.LoadUsers();
                // The outer while loop will restart login
            }

        }
    }
}
