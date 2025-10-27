namespace App; // Link or gather this class file with the rest of the classes and the executing file "program.cs".

public class Room
{
    public int Room_Number;
    public RoomStatus status;
    public string GuestName;

}




// add enum room status for room state

public enum RoomStatus
{
    Available,//free for book
    Occupied,//guest is stay
   Unavailable// outb of service
}