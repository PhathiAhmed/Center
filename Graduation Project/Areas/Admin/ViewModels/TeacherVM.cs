using Graduation_Project.Models;

namespace Graduation_Project.Areas.Admin.ViewModels
{
    public class TeacherVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public TeacherGender Gender { get; set; }
    }
    //public enum TeacherGender
    //{
    //    Male,
    //    Female
    //}
}
