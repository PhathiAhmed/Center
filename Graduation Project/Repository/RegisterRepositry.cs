using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public class RegisterRepositry : IRegisterRepositry
    {
        CenterDBContext _centerDBContext;
        public RegisterRepositry(CenterDBContext context)
        {
            _centerDBContext = context;

        }
        public void Insert(Register newRegister)
        {
            _centerDBContext.Registers.Add(newRegister);
            _centerDBContext.SaveChanges();
        }
        public void Update(Register Newstudent, int id)
        {
            if (Newstudent != null)
            {

                Register oldsts = _centerDBContext.Registers.SingleOrDefault(x => x.Id == id);
                oldsts.FatherPhone = Newstudent.FatherPhone;
                oldsts.Phone = Newstudent.Phone;
                oldsts.FirstName = Newstudent.FirstName;
                oldsts.birthday = Newstudent.birthday;
                oldsts.LastName = Newstudent.LastName;
                oldsts.Gender = Newstudent.Gender;
                oldsts.national_Id = Newstudent.national_Id;
                oldsts.Year = Newstudent.Year;
                oldsts.Picture = Newstudent.Picture;
                //.Students.Update(Newstudent);
                _centerDBContext.SaveChanges();



            }
        }
    }
}
