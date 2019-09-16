using System;
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
          string start = CheckInDate.Substring(8, 2);
          string end = CheckOutDate.Substring(8,2);
          int x = Int32.Parse(start);
          int y = Int32.Parse(end);
          int count = y-x;
          if(count >0)
          {
            foreach(var r in Rooms)
            {
              Total += r.DailyRate;
            }
            return Total * count;
          }
          
          return Total;
        }

        public bool CheckDates()
        {
          if(CheckInDate[3] == CheckOutDate[3] && CheckInDate[2] == CheckOutDate[2])
          {
            if(CheckInDate[5] == CheckOutDate[5] && CheckInDate[6] == CheckOutDate[6])
            {
                string start = CheckInDate.Substring(8, 2);
                string end = CheckOutDate.Substring(8,2);
                int x = Int32.Parse(start);
                int y = Int32.Parse(end);
                int count = y-x;
                if(count > 0)
                {
                  return true; 
                }
            }
          }
          return false;
        }

        public void CheckPartySize()
        {
          if(Customer.PartySize<=2)
          {
            
          }
        }

        public void ConfirmRooms()
        {
          foreach (var item in Rooms)
          {
            if(item.IsOccupied == false)
            {
              item.IsOccupied = true;
            }
          }
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