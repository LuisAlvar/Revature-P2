using System.ComponentModel.DataAnnotations;

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
        public string Username {get;set;}
        public string Password { get; set; }
        public int ReservationID { get; set; }

        public override string ToString()
        {
          return $"{LastName}, {FirstName}";
        }


    }
}