using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DateTime today;
        public static readonly HttpClient httpClient = new HttpClient();
        

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
            today = DateTime.Today;
            
            
        }

        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerProfile = _context.Customers.Where(c => c.IdentityUserId == userId).ToList();
            if (customerProfile.Count == 0)
            {
                return RedirectToAction("Create", "Customers");
            }
            
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return View(customer);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Create()
        {
            
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetAddress,ZipCode,BillTotal,IdentityUserId,City,State")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;

                var address = customer.StreetAddress + ", " + customer.City + ", " + customer.State;
                //string url = ("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=AIzaSyDa7YADatqC-ikFP7JAmoeQntbDy4Qm93Q");

                
                HttpResponseMessage response = await httpClient.GetAsync("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=AIzaSyDa7YADatqC-ikFP7JAmoeQntbDy4Qm93Q");
                var result = await response.Content.ReadAsStringAsync();
                var parseResult = JObject.Parse(result);
                var lat = parseResult["results"][0]["geometry"]["location"]["lat"].Value<double>();
                var longitude = parseResult["results"][0]["geometry"]["location"]["lng"].Value<double>();


                //Then update Customer properties accordingly (lat and lng)


                customer.latitude = lat;
                customer.longitude = longitude;



                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            return View(customer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                var user = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
                user.FirstName = customer.FirstName;
                user.LastName = customer.LastName;
                user.StreetAddress = customer.StreetAddress;
                user.ZipCode = customer.ZipCode;
                user.DayofWeek = customer.DayofWeek;
                user.City = customer.City;
                user.State = customer.State;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            catch
            {
                return View();
            }
   
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

       
        public ActionResult Schedule(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            return View(customer);
        }

        public ActionResult SchedulePickUp()
        {
            Schedule schedule = new Schedule();
            return View();
        }

        [HttpPost, ActionName("SchedulePickUp")]
        [ValidateAntiForgeryToken]

        public ActionResult SchedulePickUp(Schedule schedule)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var id = customer.Id;
            var address = customer.StreetAddress;
            var zipCode = customer.ZipCode;
            try
            {
                schedule.DayId = AssignDayId(schedule);
                schedule.CustomerId = id;
                schedule.CustomerAddress = address;
                schedule.CustomerZipCode = zipCode;
                schedule.PickedUp = false;
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }           
        }

        public int AssignDayId(Schedule schedule)
        {
            switch (schedule.DayName)
            {
                case "Sunday":
                    schedule.DayId = 1;
                    break;
                case "Monday":
                    schedule.DayId = 2;
                    break;
                case "Tuesday":
                    schedule.DayId = 3;
                    break;
                case "Wednesday":
                    schedule.DayId = 4;
                    break;
                case "Thursday":
                    schedule.DayId = 5;
                    break;
                case "Friday":
                    schedule.DayId = 6;
                    break;
                case "Saturday":
                    schedule.DayId = 7;
                    break;
            }
            return schedule.DayId;
        }

        public ActionResult ScheduleHold()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return View(customer);
        }

        [HttpPost, ActionName("ScheduleHold")]
        [ValidateAntiForgeryToken]

        public ActionResult ScheduleHold(int id, Customer customer)
        {
            try
            {
                var user = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
                user.FirstName = customer.FirstName;
                user.LastName = customer.LastName;
                user.StreetAddress = customer.StreetAddress;
                user.ZipCode = customer.ZipCode;
                user.DayofWeek = customer.DayofWeek;
                user.holdStart = customer.holdStart;
                user.holdEnd = customer.holdEnd;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }
    }
}
