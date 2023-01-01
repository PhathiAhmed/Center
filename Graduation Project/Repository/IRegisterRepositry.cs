using Graduation_Project.Models;
 
namespace Graduation_Project.Repository
{
    public interface IRegisterRepositry
    {
        void Insert(Register newRegister);
        public void Update(Register Newstudent, int id);
    }
    

}
