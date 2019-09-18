using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypSuite.Domain.Models
{
    public class Location{
        [Required]
        public string Street { get; set; }
        [Required]
        public string City {get;set;}
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Key]
        public int LocationID { get; set; }
        public int ClientLocationsID { get; set; }
        public HotelClient Client { get; set; }
        
        
        [ForeignKey("LocationRefID")]
        public List<Room> Rooms { get; set; }
        [Required]
        [NotMapped]
        public List<Location> Nearby {get;set;}
        [NotMapped]
        public List<Location> LocationList {get;set;}
        public override string ToString()
        {
          return $"{Street}, {City}, {State}";
        }
    }
}