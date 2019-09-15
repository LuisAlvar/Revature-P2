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
        public string Username {get;set;}
        public string Password { get; set; }
        
        [ForeignKey("ClientID")]
        [NotMapped]
        public int ClientID { get; set; }

        public override string ToString()
        {
          return $"{LastName}, {FirstName}";
        }


    }
}