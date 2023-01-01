using Graduation_Project.Models;
using Graduation_Project.Repository;
using Graduation_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace El_Tamayez.Controllers
{
    public class MyCoursesController : Controller
    {
        IPostRepository postRepository;
        public MyCoursesController(IPostRepository _postRepository)
        {
            postRepository = _postRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        #region changed at subject posts controller
        //public IActionResult MyCourses()
        //{
        //    return View();
        //}

        //public IActionResult MyGroup()
        //{
        //    List<GetPost> posts = postRepository.GetPostWithOwner();
        //    return View(posts);
        //}

        //public IActionResult SaveInsert(Post post)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        post.StudentId = 2;
        //        post.GroupId = 2;
        //        post.LikeCounter = 0;
        //        post.PostTime = DateTime.Now;
        //        postRepository.Insert(post);
        //    }
        //    return RedirectToAction(nameof(MyGroup));
        //}
        #endregion
    }
}
