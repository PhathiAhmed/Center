using Microsoft.AspNetCore.Mvc;
using Graduation_Project.AdminRepository;
using Graduation_Project.Models;
using NuGet.DependencyResolver;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        ISubject isubject;
        IHostingEnvironment env;
        public SubjectController(ISubject _isubject,IHostingEnvironment _env)
        {
             isubject = _isubject;
            env= _env;
        }
        public IActionResult GetAllSubjects()
        {
            return View(isubject.GetAllSubjects());
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Subject subject, List<IFormFile> File) 
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
                        subject.Image = Image;
                    }

                    isubject.Add(subject);
                    return RedirectToAction(nameof(GetAllSubjects));
                }
               
            }
            return View(subject);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            return View(isubject.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Subject subject,IFormFile File) 
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string path = Path.Combine(env.WebRootPath, ("images"), File.FileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        File.CopyTo(fileStream);
                    }
                    subject.Image=File.FileName;
                }
                isubject.Edit(subject);
                return RedirectToAction(nameof(GetAllSubjects));
            }
            return View(subject);
        }
        public IActionResult Delete(int id) 
        {
            isubject.Delete(id);
            return RedirectToAction(nameof(GetAllSubjects));
        }
    }
}
