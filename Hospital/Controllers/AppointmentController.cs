using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppDbContext _context;
        public AppointmentController(AppDbContext context) => _context = context;

        public IActionResult Book()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        [HttpPost]
        public IActionResult Book(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction("Confirmation");
            }
            return View(appointment);
        }
    }
}
