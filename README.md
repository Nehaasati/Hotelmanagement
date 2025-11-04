 Hotel Room Management System

 About:
This Hotel Room Management System  user registration and login so only authorized users can access the system and allows hotel receptionists to manage room bookings, check-outs, and room maintenance status (available, occupied, or unavailable). 

 Properties:
This Hotel Management System is written in C# using .NET with the Object-Oriented Programming (OOP). The system consists of 10 files organized under the App namespace.

The files are:
- Reception.cs: Manages room operations like booking, checkout, and status updates.  
- Room.cs: Defines the structure of a hotel room (room number, status, guest name).  
- RoomStatus.cs: Enum defining room states: Available, Occupied, Unavailable.  
- User.cs: Represents a user with email and password for login.  
- Program.cs: Executes and runs the main menu-driven console application.  
- SaveData.cs: Handles persistent data storage by reading from and writing to text files.  
- rooms.txt: Stores current room data (room number, status, guest name).  
- users.txt: Stores registered user accounts (email and password).  
- README.md: This documentation file.  

> Note: The system starts with 5 default rooms (101–105), all initially available.

 As a user, you can do the following in this system:
- Register a new account  
- Log in with your email and password  
- View occupied rooms  
- View available rooms  
- Book a room for a guest  
- Check out a guest from a room  
- Mark a room as unavailable (e.g., for cleaning or repairs)  
- Make an unavailable room available again  
- Exit the system (all data is automatically saved)

 Requirements to use this package:
In order to run this system, you need the following installed on your machine:
- Visual Studio Code (version 1.80 or higher recommended)  
- .NET SDK 8.0 (e.g., version 8.0.414)  
- Git (installed and configured)  

 How to use:
 If you are using Windows:
1. Clone the repository:  
   Open Git Bash or Windows PowerShell and run:  
   
   git clone git@github.com:Nehaasati/Hotelmanagement.git
   

2. Go to the project folder:  
   
   cd HotelManagement
   

3. Run the program :  
   dotnet build
   dotnet run
   

Use the system:
- When the application starts, you’ll see options to Register or Login.  
- After logging in, you can manage rooms using the menu.  
- All changes (bookings, checkouts, room status) are saved to rooms.txt and user data to users.txt.  
