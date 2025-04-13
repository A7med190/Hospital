using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _dbContext = new ();

      

        public IActionResult Index(string Specialization, string? query)
        {
            IQueryable<Appiontment> appiontments = _dbContext.Appiontments.Include(a => a.Doctor);

            var doctors = _dbContext.Doctors.AsQueryable();
            ViewData["doctors"] = doctors.ToList();

            if (!string.IsNullOrEmpty(Specialization))
            {
                doctors = doctors.Where(d => d.Specialization == Specialization);
                ViewBag.Specialization = Specialization;
            }

            if (!string.IsNullOrEmpty(query))
            {
                doctors = doctors.Where(d => d.Name.Contains(query));
                ViewBag.query = query;
            }

            return View(doctors.ToList());
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
