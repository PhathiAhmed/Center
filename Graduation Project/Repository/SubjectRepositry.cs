using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public class SubjectRepositry : ISubjectRepositry
    {

        CenterDBContext _centerDBContext;
        public SubjectRepositry( CenterDBContext context)
        {
                _centerDBContext = context;

        }

        public void Delete(int id)
        {
         //   var sub = _centerDBContext.Subjects.FirstOrDefault(x => x.Id == id);
            _centerDBContext.Subjects.Remove(GetSubjectById(id));
            _centerDBContext.SaveChanges();
        }

        public Subject GetSubjectById(int id)
        {
            return _centerDBContext.Subjects.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Subject subject)
        {
         _centerDBContext.Add(subject);
         _centerDBContext.SaveChanges();


        }

        public List<Subject> GetAllSubjects()
        {
            return _centerDBContext.Subjects.ToList();
        }

        public void Update(Subject Newsubject,int id)
        {
            Subject oldsubject =GetSubjectById(id);
            oldsubject.Name = Newsubject.Name;
            oldsubject.Description = Newsubject.Description;
            oldsubject.Year = Newsubject.Year;
            //oldsubject.AdminId = Newsubject.AdminId;
            _centerDBContext.SaveChanges();

        }

        public List<Subject> GetAllSubjectsByYear(int year)
        {
            SubjectYear y=0;
            switch (year)
            {
                case 1:
                    y = SubjectYear.First;
                    break;
                case 2:
                    y = SubjectYear.Second;
                    break;
                case 3:
                    y = SubjectYear.Third;
                    break;
                default:
                    break;
            }
            var sublects = _centerDBContext.Subjects.Where(x => (x.Year) == y).ToList();
            return sublects;
        }
    }
}
