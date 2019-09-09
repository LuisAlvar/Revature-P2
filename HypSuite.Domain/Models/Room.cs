using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HypSuite.Domain.Models
{
    public class Room
    {
        [Key]
        public int RoomID {get;set;}
        [Required]
        public int MaxCapacity { get; set; }
        public List<Bed> Beds { get; set; }
        [Required]
        public int NumberOfBathrooms {get;set;}
        public bool IsSmoking { get; set; }
        [Required]
        public int SizeSqFt {get;set;}
        [Required]
        public decimal DailyRate{get;set;}
        public bool IsOccupied {get;set;}

        public override string ToString()
        {
          return $"Room #{RoomID} has {SizeSqFt} square feet worth of space. \n It also has {Beds.Capacity} beds, {NumberOfBathrooms} bathrooms";
        } 
    }
}