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
          // foreach (var l in _db.Locations)
          // {
          //   if(location == l.State){
          //     Current.HotelsLocation.Nearby.Add(l);
          //   }           
          // }

          return View(Current.HotelsLocation);
        }

        [HttpPost]
        public IActionResult ViewLocations(Location lo)
        {
          return RedirectToAction("ViewRooms");
        }

        public IActionResult ViewRooms()
        {
          return View();
        }
        [HttpPost]
        public IActionResult ViewRooms(Room r)
        {
          return RedirectToAction("MakeReservation");
        }
        
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
