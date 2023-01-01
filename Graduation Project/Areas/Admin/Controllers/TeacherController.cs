using Microsoft.AspNetCore.Mvc;
using Graduation_Project.AdminRepository;
using Graduation_Project.Models;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        ITeacher iteacher;

        IHostingEnvironment env;
        public TeacherController(ITeacher _iteacher, IHostingEnvironment _env)
        {
            iteacher = _iteacher;
            env = _env;
        }
        public IActionResult GetAllTeachers()
        {
            return View(iteacher.GetAllTeachers());
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Add(Teacher teacher, List<IFormFile> File) 
        {
            if (ModelState.IsValid == true) 
            {
                foreach (var file in File)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images", Image);
                        using (var stream = System.IO.File.Create(FilePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        teacher.Picture = Image;
                    }

                    iteacher.Add(teacher);
                    return RedirectToAction(nameof(GetAllTeachers));
                }
                
            }
            return View(teacher);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            return View(iteacher.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Teacher teacher,int id, IFormFile File) 
        {
            if (ModelState.IsValid == true) 
            {
               
                if (File != null)
                {
                    string path = Path.Combine(env.WebRootPath, ("images"), File.FileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        File.CopyTo(fileStream);
                    }
                    teacher.Picture = File.FileName;
                    iteacher.Edit(teacher);
                    return RedirectToAction(nameof(GetAllTeachers));
                }
            }
            return View(teacher);
        }
        public IActionResult Delete(int id) 
        {

            iteacher.Delete(id);
            return RedirectToAction(nameof(GetAllTeachers));
        }
    }
}
