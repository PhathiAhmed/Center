using Microsoft.AspNetCore.Mvc;
using Graduation_Project.AdminRepository;
using Graduation_Project.Models;
namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        IContactUs icontactus;
        public ContactUsController(IContactUs _icontactus)
        {
            icontactus=_icontactus;

        }
        public IActionResult GetAllContatUsMessages()
        {
            return View(icontactus.GetContactUs());
        }
        public IActionResult Delete(int id) 
        {
            icontactus.Delete(id);
            return RedirectToAction(nameof(GetAllContatUsMessages));
        }
    }
}
