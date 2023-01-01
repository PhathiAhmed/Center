using Graduation_Project.Models;
namespace Graduation_Project.Areas.Admin.ViewModels
{
    public class AddGroupSubjectVM
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        //public Group Group { get; set; }
        public List<Subject>? Subjects { get; set; }
    }
}
