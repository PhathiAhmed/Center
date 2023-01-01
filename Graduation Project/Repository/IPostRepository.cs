namespace Graduation_Project.Repository;

using Graduation_Project.Models;
using Graduation_Project.ViewModels;

public interface IPostRepository
{
    List<Post> GetAllPosts();
    List<Post> GetAllPostsForAdmin();
    Post getPostByIdForAdmin(int id);
    List<GetPost> GetPostForAdmin();
    List<GetPost> GetPostWithOwner();
    int DeletePost(int id);
    int Insert(Post post);
    List<GetPost> getPostsForSubject(int id);
    Post getPostById(int id);
    void incrementLikeCounter(Post p);
}
