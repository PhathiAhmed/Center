using Graduation_Project.Models;
using System.Collections.Generic;
namespace Graduation_Project.AdminRepository
{

    public interface IRegister 
    {
        List<Register> GetRegisters();
        Register GetById(int id);
        bool Delete(int id);
    }
    public class RegisterRepository:IRegister
    {
        CenterDBContext db;
        public RegisterRepository(CenterDBContext _db)
        {
            db = _db;
        }
        
        public List<Register> GetRegisters()
        {
            List<Register> registers = db.Registers.OrderByDescending(s=>s.Id).ToList();
            return registers;
        }
        public Register GetById(int id) 
        {
            Register register = db.Registers.FirstOrDefault(s => s.Id == id);
            return register;
        }
        public bool Delete(int id) 
        {
            try 
            {
                Register register = GetById(id);
                db.Registers.Remove(register);
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
