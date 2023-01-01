namespace Graduation_Project.Repository;
using Graduation_Project.Models;
using Graduation_Project.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class PostRepository : IPostRepository
{
    CenterDBContext db;
    public PostRepository(CenterDBContext _db)
    {
        db = _db;
    }
    public List<Post> GetAllPosts()
    {
        return db.Posts.ToList();
    }
    public List<Post> GetAllPostsForAdmin()
    {
        return db.Posts.Where(n => n.AdminId != null).ToList();
    }
    public List<GetPost> GetPostForAdmin()
    {
        //@ get all posts which havw been writen by admin
        List<Post> posts = this.GetAllPostsForAdmin();
        // define posts which will be show at HomePost Page
        List<GetPost> postWithInfo = new List<GetPost>();
        // fill post with admin information
        foreach (var item in posts)
        {
            GetPost p = new GetPost();
            p.PostMakerId = db.Admins.Where(n => n.Id == item.AdminId).Select(n => n.Id).FirstOrDefault();
            p.likes = item.LikeCounter;
            p.PostMakerName = db.Admins.Where(n => n.Id == item.AdminId).Select(n => n.Name).FirstOrDefault();
            p.PostDate = item.PostTime;
            p.PostMakerImage = null;
            p.Image = item.Picture;
            p.Content = item.Content;
            p.PostId = item.Id;
            postWithInfo.Add(p);
        }
        return postWithInfo;
    }
    public List<GetPost> getPostsForSubject(int id)
    {
        //@ get all posts for subject
        List<Post> posts = db.Posts.Where(n => n.GroupId == id && n.AdminId == null).ToList();
        // define posts which will be show at HomePost Page
        List<GetPost> postWithInfo = new List<GetPost>();
        // fill post with admin information
        foreach (var item in posts)
        {
            GetPost p = new GetPost();
            p.likes = item.LikeCounter;
            p.PostDate = item.PostTime;
            p.Content = item.Content;
            p.PostId = item.Id;
            p.Image = item.Picture;
            if (item.StudentId != null)
            {
                Student s = db.Students.Where(n => n.Id == item.StudentId).SingleOrDefault();
                p.PostMakerId = s.Id;
                p.PostMakerName = s.FirstName + " " + s.LastName;
                p.PostMakerImage = s.Picture;
                postWithInfo.Add(p);
            }

            else if (item.TeacherId != null)
            {
                Teacher t = db.Teachers.Where(n => n.Id == item.TeacherId).SingleOrDefault();
                p.PostMakerId = t.Id;
                p.PostMakerName = t.FirstName + " " + t.LastName;
                p.PostMakerImage = t.Picture;
                postWithInfo.Add(p);
            }
        }
        return postWithInfo;
    }

    public List<GetPost> GetPostWithOwner()
    {
        List<Post> posts = this.GetAllPosts();
        List<GetPost> postWithInfo = new List<GetPost>();
        foreach (var item in posts)
        {
            if (item.StudentId != null)
            {
                GetPost p = new GetPost();
                p.PostMakerId = db.Students.Where(n => n.Id == item.StudentId).Select(n => n.Id).FirstOrDefault();
                p.likes = item.LikeCounter;
                p.PostMakerName = db.Students.Where(n => n.Id == item.StudentId).Select(n => n.FirstName + " " + n.LastName).FirstOrDefault();
                p.PostDate = item.PostTime;
                p.PostMakerImage = db.Students.Where(n => n.Id == item.StudentId).Select(n => n.Picture).FirstOrDefault();
                p.Content = item.Content;
                postWithInfo.Add(p);
            }

            else if (item.TeacherId != null)
            {
                GetPost p = new GetPost();
                p.PostMakerId = db.Teachers.Where(n => n.Id == item.TeacherId).Select(n => n.Id).FirstOrDefault();
                p.likes = item.LikeCounter;
                p.PostMakerName = db.Teachers.Where(n => n.Id == item.TeacherId).Select(n => n.FirstName + " " + n.LastName).FirstOrDefault();
                p.PostDate = item.PostTime;
                p.PostMakerImage = db.Teachers.Where(n => n.Id == item.TeacherId).Select(n => n.Picture).FirstOrDefault(); ;
                p.Content = item.Content;
                postWithInfo.Add(p);
            }
        }
        return postWithInfo;
    }

    public int DeletePost(int id)
    {
        Post p = db.Posts.SingleOrDefault(n => n.Id == id);
        db.Posts.Remove(p);
        return db.SaveChanges();
    }

    public int Insert(Post post)
    {
        db.Posts.Add(post);
        return db.SaveChanges();
    }
    public Post getPostById(int id )
    {
        Post p = db.Posts.Include(n => n.Comments).Include(n => n.Student).Include(n => n.Teacher).SingleOrDefault(n => n.Id == id);
        return p;
    }
    public Post getPostByIdForAdmin(int id)
    {
        Post p = db.Posts.Include(n => n.Comments).Include(n => n.Student).Include(n => n.Teacher).SingleOrDefault(n => n.Id == id);
        return p;
    }

    public void incrementLikeCounter(Post p)
    {
        Post newpost = this.getPostById(p.Id);
        newpost.LikeCounter++;
        db.SaveChanges();
    }
}
