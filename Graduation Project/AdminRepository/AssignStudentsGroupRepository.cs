using Graduation_Project.Models;
namespace Graduation_Project.AdminRepository
{
    public interface IAssignStudentsGroup 
    {
        bool Add(Group group);
       //bool Add(StudentSubjectGroupTeacher model);
       //List<StudentSubjectGroupTeacher> GetAllStudents();
    }


    public class AssignStudentsGroupRepository:IAssignStudentsGroup
    {
        CenterDBContext db;
        public AssignStudentsGroupRepository( CenterDBContext _db)
        {
            db = _db;
        }
        //public List<StudentSubjectGroupTeacher> GetAllStudents() 
        //{
        //    var studentsGroup = db.StudentsSubjectsGroupsTeachers.Where(s=>s.GroupId==1).ToList();

        //    return studentsGroup;

        //}

        public bool Add(Group group)
        {
            try
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
