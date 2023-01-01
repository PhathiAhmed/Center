using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;
namespace Graduation_Project.AdminRepository
{
    public interface IGroup 
    {
        List<Group> GetAll();
        Group GetById(int id);
        bool Add(Group group);
        bool Edit(Group group);
        bool Delete(int id);

    }
    public class GroupRepository:IGroup
    {
        CenterDBContext db;
        public GroupRepository(CenterDBContext _db)
        {
            db = _db;
        }
        public List<Group> GetAll() 
        {
            List<Group> groups = db.Groups.ToList();
            return groups; ;
        }
        public Group GetById(int id) 
        {
            Group group = db.Groups.FirstOrDefault(g => g.Id == id);
            return group;
        }
        public bool Add(Group group) 
        {
            try 
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        public bool Edit(Group group)
        {
            try
            {
                db.Entry(group).State = EntityState.Modified;
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
                Group group = GetById(id);
                db.Groups.Remove(group);
                db.SaveChanges();
                return true;
            }
            catch(Exception e) 
            {
                return false;
            }
        }
    }
}
