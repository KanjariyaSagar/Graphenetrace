using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ClinicianController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Clinician Dashboard";
            return View();
        }

        public IActionResult Metrics()
        {
            ViewData["Title"] = "Metrics";
            return View();
        }

        public IActionResult Patients()
        {
            ViewData["Title"] = "Patients";
            return View();
        }

        public IActionResult Alerts()
        {
            ViewData["Title"] = "Alerts";
            return View();
        }

        public IActionResult Comments()
        {
            ViewData["Title"] = "Comments";
            return View();
        }
    }
}
