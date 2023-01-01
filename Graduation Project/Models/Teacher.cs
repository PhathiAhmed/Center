using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Posts = new List<Post>();
            Comments= new List<Comment>();
           
        }
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Plz,Enetr Name More Than 3 char")]
        [MaxLength(50, ErrorMessage = "Plz,Enetr Name less Than 50 char")]
        [Required]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "Plz,Enetr Name More Than 3 char")]
        [MaxLength(50, ErrorMessage = "Plz,Enetr Name less Than 50 char")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Description { get; set; }
        public TeacherGender Gender { get; set; }
        public string? Picture { get; set; }
        public virtual List<Post>? Posts { get; set; }
        public virtual List<Comment>? Comments { get; set; }
        [ForeignKey("subjects")]
        public int? sub_Id { get; set; }
        public virtual Subject? subjects { get; set; }
        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public  Account Account { get; set; }
        //uniq
        // identity id
    }
    public enum TeacherGender
    {
        Male,
        Female
    }
}
