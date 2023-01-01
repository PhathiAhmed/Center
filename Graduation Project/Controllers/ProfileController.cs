using Graduation_Project.Models;
using Graduation_Project.Repository;
using Graduation_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Graduation_Project.Controllers;

namespace El_Tamayez.Controllers
{
    public class ProfileController : Controller
    {
        IStudentRepositry _studentRepositry;
        IHostingEnvironment _environment;
        IRegisterRepositry registerRepositry;
        CenterDBContext db;

        public ProfileController(CenterDBContext _db,IRegisterRepositry _register,IStudentRepositry studentRepositry,IHostingEnvironment hosting)
        {
            _environment = hosting;
            _studentRepositry = studentRepositry;
            registerRepositry = _register;
            db = _db;
        }
        public IActionResult Index()
        {
            Account AccountId = db.Accounts.SingleOrDefault(a => a.UserName == LoginController.UserName);

            Student st = _studentRepositry.GetStudentById(AccountId.Id);
            return View(st);
        }
        public IActionResult Edit()
        {
            Account AccountId = db.Accounts.SingleOrDefault(a => a.UserName == LoginController.UserName);

            Student st = _studentRepositry.GetStudentById(AccountId.Id);
             return View(st);
        }
        [HttpPost]
        public IActionResult UpdateStudent(StudentViewmodel newRegister,int sId)
        {
            Account AccountId = db.Accounts.SingleOrDefault(a => a.UserName == LoginController.UserName);

            if (ModelState.IsValid)
            {
                string imagename = "";
                if (newRegister.Picture != null)
                {
                    // to find folder images from wwwroot (Path of imagesfile)
                    string imagesfile = Path.Combine(_environment.WebRootPath, "images");
                    //get image name 
                    imagename = Guid.NewGuid().ToString() + newRegister.Picture.FileName;
                    string fullpath = Path.Combine(imagesfile, imagename);
                    //delete old Image from imagesfile
                    string oldimagename = _studentRepositry.GetStudentById(AccountId.Id).Picture;
                    string fulloldpath = "";
                    if (oldimagename == null)
                    {
                        fulloldpath = Path.Combine(imagesfile, imagename);

                    }
                    else
                    {
                        fulloldpath = Path.Combine(imagesfile, oldimagename);

                    }
                    //check if image chang or not 
                    if (fullpath != fulloldpath)
                    {
                        System.IO.File.Delete(fulloldpath);

                        //to save Newimage in viewmodel
                        newRegister.Picture.CopyTo(new FileStream(fullpath, FileMode.Create));
                    }
                    else if (fulloldpath == fullpath)
                    {
                        newRegister.Picture.CopyTo(new FileStream(fullpath, FileMode.Create));

                    }

                }
                else
                {

                    imagename = _studentRepositry.GetStudentById(AccountId.Id).Picture;

                }
                Student newsts = new Student()
                {
                    Phone = newRegister.Phone,
                    FatherPhone = newRegister.FatherPhone,
                    FirstName = newRegister.FirstName,
                    birthday = newRegister.birthday,
                    LastName = newRegister.LastName,
                    national_Id = newRegister.national_Id,
                    Gender = newRegister.Gender,
                    Year = newRegister.Year,
                    Picture = imagename
                };
                _studentRepositry.Update(newsts,AccountId.Id );
                return RedirectToAction("Index");

            }

            return RedirectToAction("Edit");

        }
        
    }
}
