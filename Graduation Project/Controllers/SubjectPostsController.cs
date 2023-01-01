using Graduation_Project.Models;
using Graduation_Project.Repository;
using Graduation_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Graduation_Project.Controllers
{
    public class SubjectPostsController : Controller
    {
        IPostRepository postRepository;
        ICommentRepository comment;
        IHostingEnvironment hosting;
        CenterDBContext db;
        public SubjectPostsController(IPostRepository postRepository, ICommentRepository comment, IHostingEnvironment hosting, CenterDBContext db)
        {
            this.postRepository = postRepository;
            this.comment = comment;
            this.hosting = hosting;
            this.db = db;
        }

        public IActionResult Index(int id)
        {
            List<GetPost> p = postRepository.getPostsForSubject(id);
            // send subject id for using at the post
            ViewBag.subjectId = id;
            // the left side for the group name , description and enrolle dstudents at this subject
            List<Student> s = db.Students.Where(n => n.GroupId == id).ToList();
            ViewBag.groupname =db.Groups.SingleOrDefault(n => n.Id == id).Name;
            ViewBag.groupdescription = db.Groups.SingleOrDefault(n => n.Id == id).Description;
            ViewBag.students = s;
            // user name 
            ViewBag.user = User.Identity.Name;
            // get the student image to put it near to insert post 
            Account AccountId = db.Accounts.SingleOrDefault(a => a.UserName == LoginController.UserName);
            Student student = db.Students.SingleOrDefault(x => x.AccountId == AccountId.Id);
            ViewBag.studentImage = student.Picture;
            return View(p);
        }

        public IActionResult PostContent(int id)
        {
            // get the selected post
            Post p = postRepository.getPostById(id);
            // new object from get post viewModel to show the post and it content(post content , comments , likes and number of comments)
            GetPost post = new GetPost();
            post.PostId = p.Id;
            post.Content = p.Content;
            post.likes = p.LikeCounter;
            post.Image = p.Picture;
            post.comments = p.Comments;
            post.PostDate = p.PostTime;
            //select the user info to show his data 
            if (p.StudentId != null)
            {
                post.PostMakerName = p.Student.FirstName + " " + p.Student.LastName;
                post.PostMakerImage = p.Student.Picture;
            }
            else if (p.TeacherId != null)
            {
                post.PostMakerName = p.Teacher.FirstName + " " + p.Teacher.LastName;
                post.PostMakerImage = p.Teacher.Picture;
            }
            return View(post);
        }

        public IActionResult SaveInsert(Post post, int groupId, IFormFile pic)
        {
            // get the logged in student
            Account AccountId = db.Accounts.SingleOrDefault(a => a.UserName == LoginController.UserName);
            Student s = db.Students.SingleOrDefault(x => x.AccountId == AccountId.Id);
            //  insert the related data for post
            post.StudentId = s.Id;
            post.GroupId = groupId;
            post.LikeCounter = 0;
            post.PostTime = DateTime.Now;
            //check if user inserted a photo or not
            if (pic != null)
            {
                //get images folder 
                string images = Path.Combine(hosting.WebRootPath, "images");
                // get the picture name 
                string filename = pic.FileName;
                //combine the file path and image name to gether to get the full path for the photo
                string fullpath = Path.Combine(images, filename);
                pic.CopyTo(new FileStream(fullpath, FileMode.Create));
                post.Picture = filename;
            }
            postRepository.Insert(post);
            // return to the main page for this subject
            return RedirectToAction("Index", new { id = groupId });
        }

        public IActionResult insertComment(Comment c)
        {
            // get the logged in user
            Account AccountId = db.Accounts.SingleOrDefault(a => a.UserName == LoginController.UserName);
            // check the role of logged in user to insert his name to show it with comment
            if (User.IsInRole("Student") == true)
            {
                Student s = db.Students.SingleOrDefault(x => x.AccountId == AccountId.Id);
                c.StudentId = s.Id;
                c.Content += $"@@@{s.FirstName} {s.LastName}";
            }
            else if (User.IsInRole("Teacher") == true)
            {
                Teacher s = db.Teachers.SingleOrDefault(x => x.AccountId == AccountId.Id);
                c.TeacherId = s.Id;
                c.Content += $"@@@{s.FirstName} {s.LastName}";
            }
            else if (User.IsInRole("Admin") == true)
            {
                c.AdminId = 2;
            }
            c.CommentTime = DateTime.Now;
            comment.InsertComment(c);
            return RedirectToAction(nameof(PostContent), new { id = c.postid });
        }
        // increment the like counter for the post
        public void IncrementLikeCounter(int id)
        {
            Post p = postRepository.getPostById(id);
            postRepository.incrementLikeCounter(p);
        }
    }
}