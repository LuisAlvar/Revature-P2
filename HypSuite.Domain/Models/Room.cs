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
        public int? ReservationRefID{get;set;}
        public Reservation ReservationRef {get;set;}

        public bool IsOccupied {get;set;}
        [NotMapped]
        public List<Room> Available {get;set;}
        public int LocationRefID {get;set;}
        public Location Location { get; set; }

        public override string ToString()
        {
          return $"Room #{RoomID} (${DailyRate}) has {SizeSqFt} square feet worth of space. \n It also has {NumberOfBeds} beds, {NumberOfBathrooms} bathroom(s), and has a max capacity of {MaxCapacity} people.";
        } 
    }
}