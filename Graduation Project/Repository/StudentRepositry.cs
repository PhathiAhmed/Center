using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public class StudentRepositry : IStudentRepositry
    {
        CenterDBContext _centerDBContext;
        public StudentRepositry(CenterDBContext context)
        {
            _centerDBContext = context;

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudentsByYear(int year)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(string id)
        {
            return _centerDBContext.Students.FirstOrDefault(x => x.AccountId == id);
        }

        public void Insert(Student Student)
        {
            if(Student!= null)
            {
                _centerDBContext.Students.Add(Student);
                _centerDBContext.SaveChanges();
            }

        }

        public void Update(Student Newstudent,string id)
        {
            if (Newstudent != null)
            {
                
                Student oldsts = _centerDBContext.Students.SingleOrDefault(x => x.AccountId == id);
                oldsts.FatherPhone = Newstudent.FatherPhone;
                oldsts.Phone = Newstudent.Phone;
                oldsts.FirstName= Newstudent.FirstName;
                oldsts.birthday = Newstudent.birthday;
                oldsts.LastName= Newstudent.LastName;
                oldsts.Gender= Newstudent.Gender;
                oldsts.national_Id= Newstudent.national_Id;
                oldsts.Year = Newstudent.Year;
                oldsts.Picture = Newstudent.Picture;
                //.Students.Update(Newstudent);
                _centerDBContext.SaveChanges();



            }

        }
    }
}
