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
          return View();
        }
        [HttpPost]
        public IActionResult ChooseRegion(string location)
        {
          return RedirectToAction("ViewLocations", location);
        }
        public IActionResult ViewLocations(string location)
        {
          Current = new Reservation();
          Current.HotelsLocation = new Location();
          Current.HotelsLocation.Nearby = new List<Location>();
          foreach (var l in _db.Locations)
          {
            if(location == l.State){
              Current.HotelsLocation.Nearby.Add(l);
            }           
          }

          return View(Current.HotelsLocation);
        }

        [HttpPost]
        public IActionResult ViewLocations(Location lo)
        {
          Current.HotelsLocation = lo;
          return RedirectToAction("ViewRooms");
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
                Current.Rooms.Add(r);
              }
          }
          return RedirectToAction("AddMore");
        }

        public IActionResult AddMore()
        {
          return View();
        }

        public IActionResult ViewReservation()
        {
          return View(Current);
        }
        
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}






