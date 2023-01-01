using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace Graduation_Project.Models
{
    public class Register
    {

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
        [RegularExpression("(010|012|015)[0-9]{8}", ErrorMessage = "plz,Enter Valid Phone Number")]
        [Required]
        public string Phone { get; set; }
        [RegularExpression("(010|012|015)[0-9]{8}", ErrorMessage = "plz,Enter Valid Phone Number")]
        [Required]
        public string FatherPhone { get; set; }
        [Required]
        public Gender Gender { get; set; }
        //[Required]
        [AllowNull]
        public string? Picture { get; set; }
        [Required]
        public Year Year { get; set; }
        [Required]
        public DateTime birthday { get; set; }
        [RegularExpression("[0-9]{14}",ErrorMessage ="plz, Enter valid 14 number")]
        [MaxLength(14)]
        [MinLength(14)]
        [Required]
        
        public string national_Id { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }

}
