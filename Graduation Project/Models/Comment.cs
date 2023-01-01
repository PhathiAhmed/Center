using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class Comment
    {
        //public Comment()
        //{
        //    this.CommentTime= DateTime.Now;
        //}
        //Submiter
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }

        [ForeignKey("Post")]
        public int postid { get; set; }
        public Post? Post { get; set; }
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }

    }
}
