using Microsoft.AspNetCore.Mvc;
using Graduation_Project.Models;
using Graduation_Project.AdminRepository;
using Graduation_Project.Areas.Admin.ViewModels;
namespace Graduation_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssignStudentsToGroupController : Controller
    {
        IStudent istudent;
        IGroup igroup;
        public AssignStudentsToGroupController( IStudent _istudent,IGroup _igroup)
        {
            istudent = _istudent;
            igroup = _igroup;
        }
        public IActionResult AssignStudentGroup(int id)
        {
            List<Student> students = istudent.GetAllStudents();
            Group group = igroup.GetById(id);
            AddGroupStudentVM model = new AddGroupStudentVM()
            {
                Students = students,
                Group=group
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AssignStudentGroup(AddGroupStudentVM addGroupStudentvm,int id) 
        {
            Group group = igroup.GetById(id);
            
            
            if (ModelState.IsValid) 
            {
                foreach (var item in addGroupStudentvm.MultiStudents)
                {
                    Student student = istudent.GetById(item);
                    student.GroupId = group.Id;
                    istudent.Edit(student);
                }
                return RedirectToAction("Index","Home");
            }

            return View(addGroupStudentvm);
        }
    }
}
