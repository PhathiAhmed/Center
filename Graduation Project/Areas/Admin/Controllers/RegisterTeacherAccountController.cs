using Microsoft.AspNetCore.Mvc;
using Graduation_Project.Areas.Admin.ViewModels;
using Graduation_Project.Models;
using Microsoft.AspNetCore.Identity;
namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterTeacherAccountController : Controller
    {
        private UserManager<Account> _UserManager;
        private SignInManager<Account> _SignInManager;
        CenterDBContext db;
        public RegisterTeacherAccountController(UserManager<Account> _UserManager, SignInManager<Account> _SignInManager, CenterDBContext db)
        {
            this._UserManager = _UserManager;
            this._SignInManager = _SignInManager;
            this.db = db;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(TeacherVM teacherVM)
        {


            if (ModelState.IsValid == true)
            {
                Account account = new Account()
                {
                    UserName = teacherVM.UserName,
                    Email = teacherVM.Email,

                };
                IdentityResult result = await _UserManager.CreateAsync(account, teacherVM.Password);
                await _UserManager.AddToRoleAsync(account, "Teacher");

                if (result.Succeeded)
                {
                    await _SignInManager.SignInAsync(account, false);
                    Teacher teacher = new Teacher();
                    teacher.FirstName = teacherVM.FirstName;
                    teacher.LastName = teacherVM.LastName;
                    teacher.Description = teacherVM.Description;
                    teacher.Gender = teacherVM.Gender;

                    teacher.AccountId = account.Id;


                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    return RedirectToAction("GetAllTeachers", "Teacher");

                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                return View(teacherVM);

            }
            return View(teacherVM);
        }
    }
}
