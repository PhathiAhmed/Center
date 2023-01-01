using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public interface ISubjectRepositry
    {
        List<Subject> GetAllSubjects();
        List<Subject> GetAllSubjectsByYear(int year);
        Subject GetSubjectById(int id);
        void Insert(Subject subject);
        void Update(Subject Newsubject, int id);
        void Delete(int id);

        
    }
}
