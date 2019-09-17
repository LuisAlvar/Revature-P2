using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HypSuite.Client.Models;
using HypSuite.Domain.Models;
using HypSuite.Data;

namespace HypSuite.Client.Controllers
{
    public class GuestController : Controller
    {
        private HypSuiteDBContext _db = new HypSuiteDBContext();
        public static Reservation Current {get;set;}
        public static Guest CurrentGuest {get;set;}
        
        public IActionResult ChooseRegion()
        {
          Current = new Reservation();
          Current.HotelsLocation = new Location();
          return View(Current.HotelsLocation);
        }
        [HttpPost]
        public IActionResult ChooseRegion(Location location)
        {
          Current.HotelsLocation.State = location.State;
          return RedirectToAction("ViewLocations");
        }
        public IActionResult ViewLocations()
        {
          Current.HotelsLocation.Nearby = new List<Location>();
          foreach (var l in _db.Locations)
          {
            if(Current.HotelsLocation.State == l.State){
              Current.HotelsLocation.Nearby.Add(l);
            }           
          }

          return View(Current.HotelsLocation);
        }

        [HttpPost]
        public IActionResult ViewLocations(Location lo)
        {
          Current.HotelsLocation.Rooms = new List<Room>();
          foreach (var l in _db.Locations)
          {
            if(l.Street == lo.Street){
              Current.HotelsLocation.Street = l.Street;
              Current.HotelsLocation.State = l.State;
              Current.HotelsLocation.ClientID = l.ClientID;
              Current.HotelsLocation.LocationID = l.LocationID;
              Current.HotelsLocation.City = l.City;
              Current.HotelsLocation.Rooms = l.Rooms;
              Current.HotelsLocation.ZipCode = l.ZipCode;
            }           
          }
          return RedirectToAction("GuestInformation");
        }

        public IActionResult ViewRooms()
        {
          Room r = new Room();
          r.Available = new List<Room>();
          foreach(var v in _db.Rooms)
          {
            if(v.LocationID == Current.HotelsLocation.LocationID)
            {
              if(v.IsOccupied == false)
              {
                if(CurrentGuest.PartySize ==2)
                {
                  if(v.MaxCapacity<=2)
                  {
                    r.Available.Add(v);
                  }
                }

                else if(CurrentGuest.PartySize ==1)
                {
                  if(v.NumberOfBeds<2)
                  {
                    r.Available.Add(v);
                  }
                } 

                else
                {
                  r.Available.Add(v);
                }
              }
            }
          }
          return View(r);
        }
        [HttpPost]
        public IActionResult ViewRooms(Room r)
        {
          foreach (var item in _db.Rooms)
          {
              if(item.RoomID == r.RoomID)
              {
                Current.Rooms.Add(item);
                item.IsOccupied = true;
              }
          }
          if(CurrentGuest.PartySize >1){
            return RedirectToAction("AddMore");
          }
          else
          {
            return RedirectToAction("ViewReservation");
          }
        }

        public IActionResult AddMore()
        {
          return View();
        }

        public IActionResult GuestInformation()
        {
          CurrentGuest = new Guest();
          return View(CurrentGuest);
        }
        [HttpPost]
        public IActionResult GuestInformation(Guest g)
        {
          CurrentGuest = g;
          CurrentGuest.ClientID = Current.HotelsLocation.ClientID;
          Current.Customer = new Guest();
          Current.Customer.FirstName = CurrentGuest.FirstName;
          Current.Customer.LastName = CurrentGuest.LastName;
          Current.NumberOfGuests = CurrentGuest.PartySize;
          return RedirectToAction("ReservationDates");
        }
        
        public IActionResult ReservationDates()
        {
          return View(Current);
        }
        [HttpPost]
        public IActionResult ReservationDates(Reservation res)
        {
          if(res.CheckDates())
          {
            Current.CheckInDate = res.CheckInDate;
            Current.CheckOutDate = res.CheckOutDate;
            return RedirectToAction("ViewRooms");
          }
          return View();
        }

        public IActionResult ViewReservation()
        {
          Current.ConfirmRooms();
          return View(Current);
        }

        public IActionResult ConfirmReservation()
        {
          _db.Guests.Add(CurrentGuest);
          _db.SaveChanges();
          foreach (var item in _db.Guests)
          {
              if(item.FirstName == CurrentGuest.FirstName && item.LastName == CurrentGuest.LastName)
              {
                CurrentGuest.GuestID = item.GuestID;
              }
          }          
          Current.Customer.GuestID = CurrentGuest.GuestID;
          Current.Total = Current.CalculateReservationCost();
          _db.Reservations.Add(Current);
          _db.SaveChanges();
          return View(Current);
        }

        public IActionResult RemoveRoom()
        {
          if(Current.Rooms.Capacity == 0)
          {
            return RedirectToAction("ViewRooms");
          }
          //else if(Current.Rooms.ElementAt(0) != null && Current.Rooms.Exists(r=>r.RoomID >0))
          else if (Current.Rooms.Count == 1)
          {
            Current.Rooms.RemoveAt(0);
            return RedirectToAction("ViewRooms");
          }
          else 
          {
            return View(Current);
          }
        }

        [HttpDelete]
        public IActionResult RemoveRoom(Reservation r)
        {
          int i = 0;
          foreach (var item in Current.Rooms)
          {
            if(r.Rooms[i].RoomID == item.RoomID)
            {
              Current.Rooms.RemoveAt(item.RoomID);
            }
            i++;
          }
          return RedirectToAction("ViewReservation");
        }

        public IActionResult LookUpReservation()
        {
          return View();
        }
        [HttpPost]
        public IActionResult LookUpReservation(Reservation reservation)
        {
          Current = new Reservation();
          foreach (var item in _db.Reservations)
          {
            if (item.ReservationID == reservation.ReservationID)
            {
              Current.Rooms = item.Rooms;
              Current.ReservationID = item.ReservationID;
              Current.NumberOfGuests = item.NumberOfGuests;
              Current.HotelsLocation = item.HotelsLocation;
              Current.Total = item.Total;
              Current.CheckOutDate = item.CheckOutDate;
              Current.CheckInDate = item.CheckInDate;
              Current.Customer = item.Customer;
            }
          }
          return RedirectToAction("ViewReservation");
        }
        
        
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}






