using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Repository
{
    public class CommentRepository : ICommentRepository
    {
        CenterDBContext db;
        public CommentRepository(CenterDBContext context)
        {
            db = context;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllCommentsForPost(int postId)
        {
            List<Comment> comments = db.Comments.Include(c => c.Student).Where(n => n.postid == postId).ToList();
            return comments;
        }

        public Comment GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public int InsertComment(Comment comment)
        {
            db.Comments.Add(comment);
            return db.SaveChanges();
        }
    }
}
