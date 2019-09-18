using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypSuite.Domain.Models
{
    public class HotelClient
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Name{get;set;}
        [ForeignKey("ClientHistoryID")]
        public List<Reservation> ReservationHistory { get; set; }
        [ForeignKey("ClientGuestsID")]
        public List<Guest> GuestList {get;set;}
        [ForeignKey("ClientLocationsID")]
        public List<Location> Locations {get;set;}
        public string PhoneNumber{get;set;}
        public string Email {get;set;}
        
    }
}