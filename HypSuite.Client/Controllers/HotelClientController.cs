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
    public class HotelClientController : Controller
    {
      public static HotelClient CurrentClient {get;set;}
      public static Location CurrentLocation {get;set;}
      private HypSuiteDBContext _db = new HypSuiteDBContext();
        public IActionResult Index()
        {
          return View();
        }

        public IActionResult ClientLogin()
        {
          return View();
        }

        [HttpPost]
        public IActionResult ClientLogin(HotelClient client)
        {
          foreach (var u in _db.Clients)
          {
            if(u.Name == client.Name){
              CurrentClient = new HotelClient();
              CurrentClient.Name = client.Name;
              CurrentClient.ClientID = u.ClientID;
              CurrentClient.Email = client.Email;
              CurrentClient.PhoneNumber = client.PhoneNumber; 
              return RedirectToAction("ClientPortal");
            }
          }
          return View();
        }

        public IActionResult ClientPortal()
        {
          return View();
        }

        public IActionResult ClientInfo()
        {
          return View();
        }

        public IActionResult ChooseLocation()
        {
          CurrentClient.Locations = new List<Location>();
          CurrentLocation = new Location();
          CurrentLocation.LocationList = new List<Location>();
          foreach (var l in _db.Locations)
          {
            if(CurrentClient.ClientID == l.ClientID){
              CurrentClient.Locations.Add(l);
              CurrentLocation.LocationList.Add(l);
            }           
          }
          ViewBag.Current = CurrentClient.Locations; 

          return View(CurrentLocation);
        }
        [HttpPost]
        public IActionResult ChooseLocation(Location l)
        {
          CurrentLocation.LocationID = l.LocationID;
          return RedirectToAction("CreateRoom");
        }
        
        public IActionResult CreateRoom()
        {
          return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(Room room)
        {
          if(ModelState.IsValid)
          {
            try{
                room.LocationID = CurrentLocation.LocationID;
                room.ReservationID = null;
                _db.Rooms.Add(room);
                _db.SaveChanges();  
                return RedirectToAction("ClientPortal");
            }
            catch
            {
              return View();
            }
          
          }
          return View(); 
          
          // DB Logic
          // System.Console.WriteLine("\n\n\n" + room.RoomID);
          // System.Console.WriteLine(room.MaxCapacity);
          // System.Console.WriteLine(room.IsSmoking + "\n\n\n");
        }

        public IActionResult UpdateRooms()
        {
          return View();
        }

        public IActionResult CreateLocation()
        {
          Location l = new Location();
          return View(l);
        }

        [HttpPost]
        public IActionResult CreateLocation(Location location)
        {
            try{
                location.ClientID = CurrentClient.ClientID;
                CurrentLocation = new Location();
                CurrentLocation = location;
                _db.Locations.Add(location);
                _db.SaveChanges();  
            }
            catch
            {
              return View();
            }
            
            return RedirectToAction("CreateRoom");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
