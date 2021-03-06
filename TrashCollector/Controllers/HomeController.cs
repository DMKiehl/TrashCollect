﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext _context;
  

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return View();
            }

            var customerProfile = _context.Customers.Where(c => c.IdentityUserId == userId).ToList();
            var employeeProfile = _context.Employees.Where(e => e.IdentityUserId == userId).ToList();

            if (customerProfile.Count == 1)
            {
                return RedirectToAction("Index", "Customers");
            }

            else if (employeeProfile.Count == 1)
            {
                return RedirectToAction("Schedule", "Employees");
            }

            else
            {
                return View();
            }
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
