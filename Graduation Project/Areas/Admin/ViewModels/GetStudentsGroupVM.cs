using Graduation_Project.Models; 
namespace Graduation_Project.Areas.Admin.ViewModels
{
    public class GetStudentsGroupVM
    {
        public StudentSubjectGroupTeacher StudentSubjectGroupTeacher { get; set; }
        public List<Student>? Students { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
