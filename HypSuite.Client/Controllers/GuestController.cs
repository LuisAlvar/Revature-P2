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
          return RedirectToAction("ReservationDates");
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
                r.Available.Add(v);
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
          return RedirectToAction("AddMore");
        }

        public IActionResult AddMore()
        {
          return View();
        }

        public IActionResult ReservationDates()
        {
          return View(Current);
        }
        [HttpPost]
        public IActionResult ReservationDates(Reservation res)
        {
          Current.CheckInDate = res.CheckInDate;
          Current.CheckOutDate = res.CheckOutDate;
          return RedirectToAction("ViewRooms");
        }

        public IActionResult ViewReservation()
        {
          return View(Current);
        }

        public IActionResult ConfirmReservation()
        {
          return View(Current);
        }

        public IActionResult RemoveRoom()
        {
          if(Current.Rooms.Capacity == 0)
          {
            return RedirectToAction("ViewRooms");
          }
          else if(Current.Rooms.FindLastIndex(r => r != null) == 0)
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
        public IActionResult RemoveRoom(int RoomID)
        {
          return View();
        }
        
        
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}






