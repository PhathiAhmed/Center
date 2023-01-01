using Graduation_Project.Areas.Admin.ViewModels;
using Graduation_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
 

namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterAccountController : Controller
    {
        private UserManager<Account> _UserManager;
        private SignInManager<Account> _SignInManager;
        CenterDBContext db;

        public RegisterAccountController(UserManager<Account> _UserManager,SignInManager<Account> _SignInManager, CenterDBContext db)

        {
            this._UserManager = _UserManager;
            this._SignInManager = _SignInManager;
            this.db = db;
        }
        public IActionResult RegisterAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAccount(AdminRegisterVM registerAccountVM)
        {
            
            if (ModelState.IsValid == true)
            {
                Account account = new Account()
                {
                    UserName = registerAccountVM.UserName,
                    Email = registerAccountVM.Email,

                };
                IdentityResult result = await _UserManager.CreateAsync(account, registerAccountVM.Password);
                await _UserManager.AddToRoleAsync(account, "Admin");
                if (result.Succeeded)
                {
                    await _SignInManager.SignInAsync(account,false);
                    Graduation_Project.Models.Admin admin = new Graduation_Project.Models.Admin();
                    admin.Name=registerAccountVM.Name;
                    admin.AccountId=account.Id;

                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                return View(registerAccountVM);
                
            }
            return View(registerAccountVM);
        }
    }
}
