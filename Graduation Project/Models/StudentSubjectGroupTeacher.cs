using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class StudentSubjectGroupTeacher
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        public int Grade { get; set; }

    }
}
