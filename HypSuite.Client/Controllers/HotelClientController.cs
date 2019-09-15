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
                //room.LocationID = CurrentClient.;
                _db.Rooms.Add(room);
                _db.SaveChanges();  
            }
            catch
            {
              return View();
            }
          
            return RedirectToAction("ClientPortal");
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
                _db.Locations.Add(location);
                _db.SaveChanges();  
            }
            catch
            {
              return View();
            }
            
            return RedirectToAction("CreateRoom", location.LocationID);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
