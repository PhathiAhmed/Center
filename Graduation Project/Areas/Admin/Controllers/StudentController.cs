using Microsoft.AspNetCore.Mvc;
using Graduation_Project.Models;
using Graduation_Project.AdminRepository;
namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        IStudent istudent;
        public StudentController(IStudent _istudent)
        {
            istudent = _istudent;
        }
        public IActionResult GetAllStudents()
        {
            return View(istudent.GetAllStudents());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid == true)
            {
                istudent.Add(student);
                return RedirectToAction(nameof(GetAllStudents));
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(istudent.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid == true)
            {
                istudent.Edit(student);
                return RedirectToAction(nameof(GetAllStudents));
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {

            istudent.Delete(id);
            return RedirectToAction(nameof(GetAllStudents));
        }
    }
}
