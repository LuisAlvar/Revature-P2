namespace HypSuite.Domain.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName {get;set;}
        public string Username{get;set;}
        public string Password {get;set;}

        public string Street {get;set;}
        public string City {get;set;}
        public string State {get;set;}
    }
}