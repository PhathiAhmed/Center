using Graduation_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Graduation_Project.ViewModels
{
    public class TeacherSubjects
    {
       
        public virtual List<Subject> sub { get; set; }
        public virtual List<Teacher> Teachers { get; set; }

 
    }
}
