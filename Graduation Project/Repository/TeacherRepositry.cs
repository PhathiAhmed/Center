using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public class TeacherRepositry : ITeacherRepositry
    {
        CenterDBContext _centerDBContext;
        public TeacherRepositry(CenterDBContext context)
        {
            _centerDBContext = context;

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetAllTeacher()
        {
          return  _centerDBContext.Teachers.ToList();
        }

        public List<Teacher> GetAllTeacherBySub(int subId)
        {
            return _centerDBContext.Teachers.Where(x=>x.sub_Id==subId).ToList();

        }

        public Teacher GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Teacher Student)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher Newstudent, int id)
        {
            throw new NotImplementedException();
        }
    }
}
