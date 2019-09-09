using System.Collections.Generic;

namespace HypSuite.Domain.Models
{
    public class HotelClient
    {
        public int ClientID { get; set; }
        public List<Room> Rooms {get;set;}
        public List<Reservation> ReservationHistory { get; set; }
        public List<Guest> GuestList {get;set;}
        public int NumberOfFloors {get;set;}
        public int RoomsPerFloor {get;set;}
        public List<Location> Locations {get;set;}
    }
}