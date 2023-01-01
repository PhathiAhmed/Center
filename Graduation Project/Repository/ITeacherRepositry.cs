using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public interface ITeacherRepositry
    {
        List<Teacher> GetAllTeacher();
        List<Teacher> GetAllTeacherBySub(int subId);
        Teacher GetTeacherById(int id);
        void Insert(Teacher Student);
        void Update(Teacher Newstudent, int id);
        void Delete(int id);
    }
}
