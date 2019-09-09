using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HypSuite.Client.Models;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}