using Graduation_Project.Models;
namespace Graduation_Project.Areas.Admin.ViewModels
{
    public class AddGroupStudentVM
    {
        public List<Student>? Students { get; set; }
        public Group? Group { get; set; }
        public string? GroupName { get; set; }
        public int[]? MultiStudents { get; set; }
    }
}
