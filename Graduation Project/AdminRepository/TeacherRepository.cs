using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;
namespace Graduation_Project.AdminRepository
{
    public interface ITeacher 
    {
        List<Teacher> GetAllTeachers();
        Teacher GetById(int id);
        bool Add(Teacher teacher);
        bool Edit(Teacher teacher);
        bool Delete(int id);
    }
    public class TeacherRepository:ITeacher
    {
        CenterDBContext db;
        public TeacherRepository(CenterDBContext _db)
        {
             db = _db;
        }
        public List<Teacher> GetAllTeachers() 
        {
            List<Teacher> teachers = db.Teachers.ToList();
            return teachers;
        } 
        public Teacher GetById(int id) 
        {
            Teacher teacher = db.Teachers.FirstOrDefault(t => t.Id == id);
            return teacher;

        }
        public bool Add(Teacher teacher) 
        {
            try 
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return true;
            }
            catch(Exception e) 
            {
                return false;
            }
        }
        public bool Edit(Teacher teacher) 
        {
            try 
            {
                db.Entry(teacher).State = EntityState.Modified;
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
                Teacher teacher = GetById(id);
                db.Teachers.Remove(teacher);
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
