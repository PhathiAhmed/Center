using Graduation_Project.Models;

namespace Graduation_Project.Areas.Admin.ViewModels

{
    public class AssignStudentsGroupVM
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public List<Student>? Students { get; set; }
        public Group? Group { get; set; }
        public int[] MultiStudents { get; set; }
    }
}
