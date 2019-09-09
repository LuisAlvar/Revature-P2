using System.ComponentModel.DataAnnotations;

namespace HypSuite.Domain.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Username{get;set;}
        [Required]
        public string Password {get;set;}
        [Required]
        public string Position {get;set;}
    }
}