using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            //  Clear auth/session if you use Identity
            return RedirectToAction("Dashboard", "Clinician");
        }
    }
}
