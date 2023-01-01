using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;
namespace Graduation_Project.AdminRepository
{
    public interface ISubject 
    {
        List<Subject> GetAllSubjects();
        Subject GetById(int id);
        bool Add(Subject subject);
        bool Edit(Subject subject);
        bool Delete(int id);
    }
    public class SubjectRepository:ISubject
    {
        CenterDBContext db;
        public SubjectRepository(CenterDBContext _db)
        {
           db = _db;
        }
        public List<Subject> GetAllSubjects() 
        { 
            List<Subject> subjects = db.Subjects.ToList();
            return subjects;  
        }
        public Subject GetById(int id) 
        {
            Subject subject = db.Subjects.FirstOrDefault(s => s.Id == id);
            return subject;
        }
        public bool Add(Subject subject)
        {
            try 
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return true;
            }
            catch(Exception e) 
            {
                return false;
            }
        }
        public bool Edit(Subject subject)
        {
            try
            {
                db.Entry(subject).State=EntityState.Modified;
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
                Subject subject = GetById(id);
                db.Subjects.Remove(subject);
                db.SaveChanges();
                return true;
            }catch(Exception e) 
            {
                return false;
            }
        }
    }
}
