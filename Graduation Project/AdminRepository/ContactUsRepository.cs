using Graduation_Project.Models;
namespace Graduation_Project.AdminRepository
{
    public interface IContactUs 
    {
        List<ContactUs> GetContactUs();
        ContactUs GetById(int id);
        bool Delete(int id);
    }
    public class ContactUsRepository:IContactUs
    {
        CenterDBContext db;
        public ContactUsRepository(CenterDBContext _db)
        {
            db = _db;
        }
        public List<ContactUs> GetContactUs() 
        {
            List<ContactUs> contactUs = db.ContactUss.ToList();
            return contactUs;
        }
        public ContactUs GetById(int id) 
        {
            ContactUs contactUs = db.ContactUss.FirstOrDefault(c => c.Id == id);
            return contactUs;
        }
        public bool Delete(int id) 
        {
            try 
            { 
                ContactUs contactUs = GetById(id);
                db.ContactUss.Remove(contactUs);
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
