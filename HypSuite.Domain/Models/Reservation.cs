using System.Collections.Generic;

namespace HypSuite.Domain.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public List<Room> Rooms { get; set; }
        public int NumberOfGuests { get; set; }
        public string CheckInDate {get;set;}
        public string CheckOutDate {get;set;}
        public Location HotelsLocation {get;set;}
    }
}