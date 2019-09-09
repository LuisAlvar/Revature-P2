using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HypSuite.Client.Models;
using HypSuite.Domain.Models;

namespace HypSuite.Client.Controllers
{
    public class HotelClientController : Controller
    {
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
          System.Console.WriteLine("\n\n\n" + room.RoomID + "\n\n\n");
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
          // DB Logic
          return RedirectToAction("ClientPortal");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
