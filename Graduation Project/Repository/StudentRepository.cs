using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public class StudentRepository : IStudentRepository
    {
        CenterDBContext db;
        public StudentRepository(CenterDBContext db)
        {
            this.db = db;
        }
        public int DeleteStudent(int id)
        {
            Student s = db.Students.FirstOrDefault(n => n.Id == id);
            db.Remove(s);
            return db.SaveChanges();
        }

        public List<Student> GetAllPosts()
        {
            return db.Students.ToList();
        }

        public int Insert(Student student)
        {
            db.Students.Add(student);
            return db.SaveChanges();
        }
    }
}
