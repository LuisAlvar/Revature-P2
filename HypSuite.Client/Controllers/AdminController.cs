using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HypSuite.Client.Models;
using HypSuite.Data;
using HypSuite.Domain.Models;

namespace HypSuite.Client.Controllers
{
    public class AdminController : Controller
    {
        private HypSuiteDBContext _db = new HypSuiteDBContext();
        public IActionResult AdminLogin()
        {
          return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Employee admin)
        { 
          foreach (var u in _db.Admin)
          {
            if(u.Username == admin.Username) {
              if(u.Password == admin.Password)
                return RedirectToAction("AdminPortal");
            }
          }
          return View();
        }

        public IActionResult AdminPortal()
        {
          return View();
        }

        public IActionResult RegisterClient()
        {
          HotelClient h = new HotelClient();
          return View();
        }

        [HttpPost]
        public IActionResult RegisterClient(HotelClient test)
        {
          if(ModelState.IsValid)
        {
          try{
              _db.Clients.Add(test);
              _db.SaveChanges();  
          }
          catch
          {
            return View();
          }
          
          return RedirectToAction("ClientPortal");
        }
          return View(); 
        }

        public IActionResult ViewClients()
        {
          return ViewClients();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}