using Graduation_Project.Models;
using Graduation_Project.Repository;
using Graduation_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    public class LoginController : Controller
    {
        public static string UserName = "";
        private UserManager<Account> _UserManager;
        private SignInManager<Account> _SignInManager;
        CenterDBContext db;
        public LoginController( UserManager<Account> _UserManager, SignInManager<Account> _SignInManager, CenterDBContext db)
        {

            this._UserManager = _UserManager;
            this._SignInManager = _SignInManager;
            this.db = db;
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                UserName = loginVM.UserName;
                Account account = await _UserManager.FindByNameAsync(loginVM.UserName);


                if (account != null)
                {
                    bool found = await _UserManager.CheckPasswordAsync(account, loginVM.Password);
                    if (found)
                    {
                        await _SignInManager.SignInAsync(account, false);

                        //I Think that must be solution by it 
                        //if (account.Student != null)
                        //{

                        //}
                        return RedirectToAction("Index", "HomePosts");
                    }
                }
                ModelState.AddModelError("", "Invalid username or password");
                return View(loginVM);
            }
            return View(loginVM);
        }
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
