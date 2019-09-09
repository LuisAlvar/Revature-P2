using System.ComponentModel.DataAnnotations;

namespace HypSuite.Domain.Models
{
    public class Bed
    {
        [Required]
        public int BedID{get;set;}
        [Required]
        public string BedSize{get;set;}
    }
}