using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypSuite.Domain.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [ForeignKey("GuestID")]
        public Guest Customer {get;set;}
        public List<Room> Rooms { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        [Required]
        public string CheckInDate {get;set;}
        [Required]
        public string CheckOutDate {get;set;}
        public Location HotelsLocation {get;set;}
        public decimal Total { get; set; }

        public decimal CalculateReservationCost()
        {
          Total = 0M;
          foreach(var r in Rooms)
          {
            Total += r.DailyRate;
          }
          return Total;
        }

        public override string ToString()
        {
          return $"Reservation ID: {ReservationID} \n\nReservation has been confirmed for: {Customer.LastName},{Customer.FirstName} \n\nReservation Location: {HotelsLocation} \n\tCheck In Date: {CheckInDate} Check Out Date: {CheckOutDate}";
        }

        public Reservation()
        {
          Rooms = new List<Room>();
        }
    }
}