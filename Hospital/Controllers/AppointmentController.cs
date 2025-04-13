using Hospital.Data;
using Microsoft.AspNetCore.Mvc;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var appointments = _dbContext.Appiontments.Include(e=> e.Doctor);
            return View(appointments.ToList());
        }

        
        public IActionResult Book( int id)
        {
            var doc = _dbContext.Doctors.FirstOrDefault(d => d.Id == id);
            return View(doc);
        }
        [HttpPost]
        public IActionResult Book( Appiontment appoint , int DoctorId)
        {

            var doc = _dbContext.Doctors.FirstOrDefault(d => d.Id == DoctorId);
            if (appoint.Date < DateOnly.FromDateTime(DateTime.Now))
            {
                return View( doc);
            }
            

            
            _dbContext.Add(new Appiontment
            {
                PatientName = appoint.PatientName,
                
                Date = appoint.Date,
                Time = appoint.Time,
                DoctorId = doc.Id
            });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}
