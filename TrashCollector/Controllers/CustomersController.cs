using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DateTime today;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
            today = DateTime.Today;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerProfile = _context.Customers.Where(c => c.IdentityUserId == userId).ToList();
            if (customerProfile.Count == 0)
            {
                return RedirectToAction("Create", "Customers");
            }
            //var user = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            //return View(user);
            
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return View(customer);

        }

        // GET: Customers/Details/5
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

        // GET: Customers/Create
        public IActionResult Create()
        {
            //Customer customer = new Customer();
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetAddress,ZipCode,BillTotal,IdentityUserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,StreetAddress,ZipCode,BillTotal,IdentityUserId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
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

        // POST: Customers/Delete/5
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
            var customer = _context.Schedules.Where(s => s.CustomerId == id).Where(s => s.date >= today.Date).SingleOrDefault();
            return View(customer);
        }

        public ActionResult SchedulePickUp()
        {
            Schedule schedule = new Schedule();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SchedulePickup(Schedule schedule)
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
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
                return RedirectToAction(nameof(Schedule));
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

    }
}
