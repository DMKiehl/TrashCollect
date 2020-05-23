using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
//using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DateTime today;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
            today = DateTime.Today;
           
        }

        // GET: Employees
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return View(employee);

        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
           
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ZipCode,IdentityUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Schedule));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            var employee = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                var user = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
                user.FirstName = employee.FirstName;
                user.LastName = employee.LastName;
                user.ZipCode = employee.ZipCode;
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

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        public ActionResult Schedule()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeProfile = _context.Employees.Where(c => c.IdentityUserId == userId).ToList();
            if (employeeProfile.Count == 0)
            {
                return RedirectToAction("Create", "Employees");
            }

            PrepareDailySchedule();
            var weekday = today.DayOfWeek.ToString();
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var display = _context.Schedules.Where(s => s.CustomerZipCode == employee.ZipCode).Where(s => s.date == today.Date).Where(s => s.PickedUp == false).AsEnumerable();
          

            return View(display);
        }

        public ActionResult ViewSchedule(string sortOrder)
        {
            var weekday = today.DayOfWeek.ToString();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var display = _context.Schedules.Where(s => s.CustomerZipCode == employee.ZipCode).AsEnumerable();
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            
            switch (sortOrder)
            {
                case "Date":
                    display = display.OrderBy(s => s.date);
                    break;
                case "date_desc":
                    display = display.OrderByDescending(s => s.date);
                    break;
                default:
                     display = display.OrderBy(s => s.CustomerAddress);
                    break;
            }
            return View(display);
        }

        public ActionResult PickedUp(int id)
        {
            
            var schedule = _context.Schedules.Where(s => s.Id == id).SingleOrDefault();
            var customer = _context.Customers.Where(c => c.Id == schedule.CustomerId).SingleOrDefault();
            schedule.PickedUp = true;
            customer.BillTotal += 10;
            _context.SaveChanges();
            return RedirectToAction(nameof(Schedule));
           
        }

        public void PrepareDailySchedule()
        {
            var weekday = today.DayOfWeek.ToString();
            var customers = _context.Customers.Where(c => c.DayofWeek == weekday).ToList();

            var onHold = new List<Customer>();
            var pickUp = new List<Customer>();
            foreach (var item in customers)
            {
                if (item.holdStart == today.Date || (item.holdStart < today.Date && today.Date <= item.holdEnd))
                {
                    onHold.Add(item);
                }

                else
                {
                    pickUp.Add(item);
                }
            }

            foreach (var item in pickUp)
            {
                

                Schedule schedule = new Schedule();
                schedule.date = today.Date;
                schedule.PickedUp = false;
                schedule.CustomerId = item.Id;
                schedule.CustomerAddress = item.StreetAddress;
                schedule.CustomerZipCode = item.ZipCode;
                schedule.DayId = AssignDayIdEmployee(item.DayofWeek);
                schedule.DayName = item.DayofWeek;
                _context.Schedules.Add(schedule);

            }
            _context.SaveChanges();

        }

        public int AssignDayIdEmployee(String day)
        {
            int dayId = 0;
            switch (day)
            {
                case "Sunday":
                     dayId= 1;
                    break;
                case "Monday":
                    dayId = 2;
                    break;
                case "Tuesday":
                    dayId = 3;
                    break;
                case "Wednesday":
                    dayId = 4;
                    break;
                case "Thursday":
                    dayId = 5;
                    break;
                case "Friday":
                    dayId = 6;
                    break;
                case "Saturday":
                    dayId = 7;
                    break;
            }
            return dayId;
        }

        public ActionResult DailySchedule()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var weekday = today.DayOfWeek.ToString();
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var display = _context.Schedules.Where(s => s.CustomerZipCode == employee.ZipCode).Where(s => s.date == today.Date).Where(s => s.PickedUp == false).AsEnumerable();


            return View(display);
        }
    }
}
