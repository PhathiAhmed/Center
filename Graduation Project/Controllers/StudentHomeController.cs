using Microsoft.AspNetCore.Mvc;

namespace El_Tamayez.Controllers
{
    public class StudentHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
