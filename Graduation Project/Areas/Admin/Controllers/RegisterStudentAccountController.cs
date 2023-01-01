using Graduation_Project.Areas.Admin.ViewModels;
using Graduation_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterStudentAccountController : Controller
    {
        private UserManager<Account> _UserManager;
        private SignInManager<Account> _SignInManager;
        CenterDBContext db;
        public RegisterStudentAccountController(UserManager<Account> _UserManager, SignInManager<Account> _SignInManager, CenterDBContext db)
        {
            this._UserManager = _UserManager;
            this._SignInManager = _SignInManager;
            this.db = db;
        }
        public IActionResult Register(int id)
        {
            Register register = db.Registers.SingleOrDefault(x => x.Id == id);
            StudentRegisterVM studentRegisterVM = new StudentRegisterVM();
            RegisterStudentAllAccountVM registerStudentAllAccountVM = new RegisterStudentAllAccountVM()
            {
                register = register,
                StudentRegisterVM = studentRegisterVM
            };


            //ViewBag.register = register;
            return View(registerStudentAllAccountVM);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterStudentAllAccountVM registerAll)
        {


            if (ModelState.IsValid == true)
            {
                Account account = new Account()
                {
                    UserName = registerAll.StudentRegisterVM.UserName+ (Guid.NewGuid()).ToString().Substring(0,4),
                    Email = registerAll.StudentRegisterVM.Email,

                };
                IdentityResult result = await _UserManager.CreateAsync(account, registerAll.StudentRegisterVM.Password);
                await _UserManager.AddToRoleAsync(account, "Student");

                if (result.Succeeded)
                {
                    await _SignInManager.SignInAsync(account, false);
                    Student student = new Student();
                    student.FirstName = registerAll.register.FirstName;
                    student.LastName = registerAll.register.LastName;
                    student.Phone = registerAll.register.Phone;
                    student.FatherPhone = registerAll.register.FatherPhone;
                    student.Year = registerAll.register.Year;
                    student.Gender = registerAll.register.Gender;
                    student.national_Id = registerAll.register.national_Id;
                    student.birthday = registerAll.register.birthday;
                    student.AccountId = account.Id;
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("GetAll", "StudentAccountInformation");

                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                return View(registerAll);

            }
            return View(registerAll);
        }
    }
}