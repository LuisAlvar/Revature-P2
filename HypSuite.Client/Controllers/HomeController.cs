using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HypSuite.Client.Models;

namespace HypSuite.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientLogin()
        {
          return View();
        }
        
        public IActionResult ClientPortal()
        {
          return View();
        }

        public IActionResult AdminLogin()
        {
          return View();
        }

        [HttpGet]
        public IActionResult AdminLogin(String username)
        {
          return RedirectToAction("AdminPortal");
        }

        public IActionResult About()
        {
          return View();
        }

        public IActionResult Privacy()
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
