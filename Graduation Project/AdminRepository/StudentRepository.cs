using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.AdminRepository
{
    public interface IStudent 
    {
        List<Student> GetAllStudents();
        Student GetById(int id);
        bool Add(Student student);
        bool Edit(Student student);
        bool Delete(int id);
    }
    public class StudentRepository:IStudent
    {
        CenterDBContext db;
        public StudentRepository(CenterDBContext _db)
        {
            db = _db;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = db.Students.ToList();
            return students;
        }
        public Student GetById(int id)
        {
            Student student = db.Students.FirstOrDefault(t => t.Id == id);
            return student;

        }
        public bool Add(Student student)
        {
            try
            {
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Edit(Student student)
        {
            try
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Student student = GetById(id);
                db.Students.Remove(student);
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
