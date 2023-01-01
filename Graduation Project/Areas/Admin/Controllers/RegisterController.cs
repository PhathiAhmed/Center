using Microsoft.AspNetCore.Mvc;
using Graduation_Project.AdminRepository;
using Graduation_Project.Models;

namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        IRegister iregister;
        public RegisterController(IRegister _iregister)
        {
            iregister = _iregister;
        }
        public IActionResult GetAllRegisteredStudents()
        {

            return View(iregister.GetRegisters());
        }
        public IActionResult Delete(int id) 
        {
            iregister.Delete(id);
            return RedirectToAction(nameof(GetAllRegisteredStudents));
        }
    }
}
