
﻿using Graduation_Project.Models;
using Graduation_Project.Repository;
using Graduation_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace El_Tamayez.Controllers
{
    
    public class HomeController : Controller
    {
        IStudentRepositry studentRepositry;
        ITeacherRepositry TeacherRepositry;
        ISubjectRepositry SubjectRepositry;
        IRegisterRepositry RegisterRepositry;
        IHostingEnvironment hosting;
        IContactusRepositry contactusRepositry;
        private UserManager<Account> _UserManager;
        private SignInManager<Account> _SignInManager;
        CenterDBContext db;

        //public HomeController()
        //{

        //}
        public HomeController(IContactusRepositry _contactusRepositry,IHostingEnvironment _hosting,IStudentRepositry _studentRepositry,IRegisterRepositry _registerRepositry ,ITeacherRepositry teacherRepositry,ISubjectRepositry _subjectRepositry, UserManager<Account> _UserManager, SignInManager<Account> _SignInManager, CenterDBContext db)
        {
            studentRepositry = _studentRepositry;
            TeacherRepositry = teacherRepositry;
            SubjectRepositry = _subjectRepositry;
            RegisterRepositry = _registerRepositry;
            hosting = _hosting;
            contactusRepositry = _contactusRepositry;
            this._UserManager = _UserManager;
            this._SignInManager = _SignInManager;
            this.db = db;
        }
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{

        //    // add static account admin
        //    // username : adminfortest
        //    // pasword : Admin123+
            
        //    if (ModelState.IsValid)
        //    {
        //        Account user = new()
        //        {
        //            UserName = "AdminForTest",
        //            Email = "admin@gmail.com",
                    
        //        };
        //        IdentityResult result = await _UserManager.CreateAsync(user, "Admin123+");
        //        await _SignInManager.SignInAsync(user, false);
        //        Graduation_Project.Models.Admin admin = new Graduation_Project.Models.Admin();
        //        admin.Name = "Admin";
        //        admin.AccountId = user.Id;

        //        db.Admins.Add(admin);
        //        db.SaveChanges();
        //        return View();

        //    }
        //    return View();

        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSubect(int year)
        {
            List<Subject> sub = SubjectRepositry.GetAllSubjectsByYear(year);
            TeacherSubjects teacherSubjects = new TeacherSubjects()
            {
                sub = sub
            };
            return PartialView("_Sub", teacherSubjects);
        }
        public IActionResult GetTeacher(int subId)
        {
            List<Teacher> tea = TeacherRepositry.GetAllTeacherBySub(subId);
            TeacherSubjects teacherSubjects = new TeacherSubjects()
            {
                Teachers = tea
            };
            return PartialView("_Teacher", teacherSubjects);
        }

       
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(StudentViewmodel newRegister)
        {

            if (ModelState.IsValid)
            {
                string imagename = "";
                if (newRegister.Picture != null)
                {
                    // to find folder images from wwwroot (Path of imagesfile)
                    string imagesfile = Path.Combine(hosting.WebRootPath, "images");
                    //get image name 
                   // imagename =   newRegister.Picture.FileName;

                    imagename = Guid.NewGuid().ToString()+ newRegister.Picture.FileName;
                    string fullpath = Path.Combine(imagesfile, imagename);
                    //to save image in viewmodel
                    newRegister.Picture.CopyTo(new FileStream(fullpath, FileMode.Create));
                }
                Register reg = new Register()
                {
                    FirstName = newRegister.FirstName,
                    LastName=newRegister.LastName,
                    Phone=newRegister.Phone,
                    FatherPhone=newRegister.FatherPhone,
                    birthday=newRegister.birthday,
                    Gender=newRegister.Gender,
                    national_Id=newRegister.national_Id,
                    Year=newRegister.Year,
                    //name of image
                    Picture=imagename

                };
                //Student st = new Student()
                //{
                //    FirstName = newRegister.FirstName,
                //    LastName = newRegister.LastName,
                //    Phone = newRegister.Phone,
                //    FatherPhone = newRegister.FatherPhone,
                //    birthday = newRegister.birthday,
                //    Gender = newRegister.Gender,
                //    national_Id = newRegister.national_Id,
                //    Year = newRegister.Year,
                //    //name of image
                //    Picture = imagename

                //};
                RegisterRepositry.Insert(reg);
                //studentRepositry.Insert(st);
                 return RedirectToAction("Index","Home");
            }
            else
            {
                return View(newRegister);
            } 
    
        }

        
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(ContactUs contact)
        {
            if (contact!=null)
            {
                contactusRepositry.Insert(contact);
                return RedirectToAction("ContactUs");
            }

            ; return RedirectToAction("ContactUs",contact);
        }
        // Admin
        
    }
    
}



//#region
//public IActionResult getSubjects(int year)
//{
//    List<Subject> subs = SubjectRepositry.GetAllSubjectsByYear(year);
//    return View(subs);

//}
//public IActionResult getTeacher(int subId)
//{
//    return View(TeacherRepositry.GetAllTeacherBySub(subId));

//}
//public IActionResult Teach()
//{
//    return RedirectToAction("getTeacher");
//}

//#endregion