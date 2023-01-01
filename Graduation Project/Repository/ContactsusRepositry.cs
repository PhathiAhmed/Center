using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public class ContactsusRepositry : IContactusRepositry
    {

        CenterDBContext _context;
        public ContactsusRepositry(CenterDBContext centerDBContext)
        {
                _context= centerDBContext;
        }

        public List<ContactUs> getallcontacts()
        {
            return _context.ContactUss.ToList();
                
        }

        public void Insert(ContactUs contactUs)
        {
            _context.ContactUss.Add(contactUs);
            _context.SaveChanges();
        }
    }
}
