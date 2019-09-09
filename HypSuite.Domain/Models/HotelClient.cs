using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HypSuite.Domain.Models
{
    public class HotelClient
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Name{get;set;}
        public List<Reservation> ReservationHistory { get; set; }
        public List<Guest> GuestList {get;set;}
        public List<Location> Locations {get;set;}
    }
}