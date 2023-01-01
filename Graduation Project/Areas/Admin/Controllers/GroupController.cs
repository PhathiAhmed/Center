using Microsoft.AspNetCore.Mvc;
using Graduation_Project.AdminRepository;
using Graduation_Project.Models;
using Graduation_Project.ViewModels;
using Graduation_Project.Areas.Admin.ViewModels;
namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        IGroup igroup;
        ISubject isubject;
        public GroupController(IGroup _igroup, ISubject _isubject)
        {
            igroup = _igroup;
            isubject = _isubject;
        }
        public IActionResult GetAllGroups()
        {
            return View(igroup.GetAll());
        }
        [HttpGet]
        public IActionResult Add() 
        {
            List<Subject> subjects = isubject.GetAllSubjects();
            AddGroupSubjectVM addGroupSubjectVM = new AddGroupSubjectVM()
            {
                Subjects = subjects
            };
            return View(addGroupSubjectVM);
        }
        [HttpPost]
        public IActionResult Add(AddGroupSubjectVM addGroupSubjectVM)
        {
            Group group = new Group();
            if (ModelState.IsValid == true) 
            {


                group.Name = addGroupSubjectVM.Name;
                group.CreationTime = addGroupSubjectVM.CreationTime;
                group.Description = addGroupSubjectVM.Description;
                group.SubjectId = addGroupSubjectVM.SubjectId;
               
                igroup.Add(group);
                return RedirectToAction(nameof(GetAllGroups));
            }
            return View(addGroupSubjectVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(igroup.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Group group)
        {
            if (ModelState.IsValid == true)
            {
                igroup.Edit(group);
                return RedirectToAction(nameof(GetAllGroups));
            }
            return View(group);
        }

        public IActionResult Delete(int id) 
        {
            igroup.Delete(id);
            return RedirectToAction(nameof(GetAllGroups));
        }
    }
}
