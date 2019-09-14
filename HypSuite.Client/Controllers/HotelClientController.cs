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
        public IActionResult ClientLogin(string test)
        {
          // DB Logic
          return RedirectToAction("ClientPortal");
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
          // DB Logic
          System.Console.WriteLine("\n\n\n" + room.RoomID);
          System.Console.WriteLine(room.MaxCapacity);
          System.Console.WriteLine(room.IsSmoking + "\n\n\n");
          return RedirectToAction("ClientPortal");
        }

        public IActionResult UpdateRooms()
        {
          return View();
        }

        public IActionResult CreateLocation()
        {
          return View();
        }

        [HttpPost]
        public IActionResult CreateLocation(Location location)
        {
          if(ModelState.IsValid)
        {
          try{
              _db.Locations.Add(location);
              _db.SaveChanges();  
          }
          catch
          {
            return RedirectToAction("WrongInput","Pizza");
          }
          
          return RedirectToAction("Index","Pizza");
        }
          return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
