using Graduation_Project.Models;

namespace Graduation_Project.Repository
{
    public interface ICommentRepository
    {
        int InsertComment(Comment comment);
        int Delete(int id);
        Comment GetCommentById(int id);
        List<Comment> GetAllComments();
        List<Comment> GetAllCommentsForPost(int postId);

    }
}
