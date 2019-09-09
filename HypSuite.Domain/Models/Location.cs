using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypSuite.Domain.Models
{
    public class Location
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City {get;set;}
        [Required]
        public string State { get; set; }
        [Key]
        public int LocationID { get; set; }
        public List<Room> Rooms { get; set; }
        [Required]
        public int NumberOfFloors { get; set; }
        [NotMapped]
        public List<Location> Nearby {get;set;}

        public override string ToString()
        {
          return $"{Street}, {City}, {State}";
        }
    }
}