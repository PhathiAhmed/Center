using Microsoft.AspNetCore.Mvc;
using Graduation_Project.Models;
using Graduation_Project.Areas.Admin.ViewModels;
using Graduation_Project.AdminRepository;

namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentAccountInformationController : Controller
    {
        CenterDBContext db;
        public StudentAccountInformationController(CenterDBContext _db)
        {
          db=_db  ;
        }
        public IActionResult GetAll()
        {
            List<Student> students = db.Students.ToList();
            List<Account> accounts = new List<Account>();
            
            foreach (var item in students)
            {

                accounts.Add(db.Accounts.SingleOrDefault(a => a.Id == item.AccountId)) ;

            }
            StudentAccountInformationVModel model = new StudentAccountInformationVModel() 
            {
                Accounts=accounts,
                Students=students
            };
            return View(model);
        }
    }
}
