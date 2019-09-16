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
        
        [ForeignKey("ClientID")]
        [NotMapped]
        public int ClientID { get; set; }

        public override string ToString()
        {
          return $"{LastName}, {FirstName}";
        }


    }
}