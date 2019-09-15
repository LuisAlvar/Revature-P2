using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypSuite.Domain.Models
{
    public class Room
    {
        [Key]
        public int RoomID {get;set;}
        [Required]
        public int MaxCapacity { get; set; }
        [Required]
        public int NumberOfBeds { get; set; }
        [Required]
        public int NumberOfBathrooms {get;set;}
        public bool IsSmoking { get; set; }
        [Required]
        public int SizeSqFt {get;set;}
        [Required]
        public decimal DailyRate{get;set;}
        [ForeignKey("ReservationID")]
        [NotMapped]
        public int ReservationID{get;set;}
        public bool IsOccupied {get;set;}
        [NotMapped]
        public List<Room> Available {get;set;}
        [ForeignKey("ClientID")]
        public int LocationID { get; set; }

        public override string ToString()
        {
          return $"Room #{RoomID} has {SizeSqFt} square feet worth of space. \n It also has {NumberOfBeds} beds, {NumberOfBathrooms} bathrooms";
        } 
    }
}