using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypSuite.Domain.Models
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int PartySize {get;set;}
        public int ClientGuestsID { get; set; }
        public HotelClient Client {get;set;}
        public override string ToString()
        {
          return $"{LastName}, {FirstName}";
        }
    }
}