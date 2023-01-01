using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public SubjectYear Year { get; set; }
        public string? Image { get; set; }
        public virtual List<Teacher>? Teachers { get; set; }
        [ForeignKey("Group")]
        public int? GrouId { get; set; }
        public Group? Group { get; set; }

    }

    public enum SubjectYear
    {
        First,
        Second,
        Third
    }
}
