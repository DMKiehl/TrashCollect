using System;
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
        //IdentityRole role;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IdentityRole Role)
        {
            _logger = logger;
            _context = context;
            //role = Role;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return View();
            }
            if (IdentityRole.Name == "Customer")
            {
                var customerProfile = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

                if (customerProfile == null)
                {
                    return RedirectToAction("Create", "Customers");
                }

                else
                {
                    return RedirectToAction("Index", "Customers");
                }
            }
            else
            {
                var employeeProfile = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                if (employeeProfile == null)
                {
                    return RedirectToAction("Create", "Employees");
                }
                else
                {
                    return RedirectToAction("Index", "Employees");
                }
            }
            
           


           


            //return View();

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
