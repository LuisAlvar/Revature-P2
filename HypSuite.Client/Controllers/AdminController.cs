using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HypSuite.Client.Models;

namespace HypSuite.Client.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminLogin()
        {
          return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(String username)
        {
          return RedirectToAction("AdminPortal");
        }

        public IActionResult AdminPortal()
        {
          return View();
        }

        public IActionResult RegisterClient()
        {
          return View();
        }

        [HttpPost]
        public IActionResult RegisterClient(string test)
        {
          // Add DB logic
          return RedirectToAction("AdminPortal");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}