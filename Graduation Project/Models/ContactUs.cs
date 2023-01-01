using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.Models
{
    public class ContactUs
    {
        [HiddenInput]
        [Key]
        public int? Id { get; set; }

        [MaxLength(50,ErrorMessage ="Name Must Less 50 Char")]
        [MinLength(3,ErrorMessage ="Name Must More 2Chaa")]
        [System.ComponentModel.DataAnnotations.Required]
         public string Name { get; set; }
        [RegularExpression("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage ="Plz, Enter Valid Email As => amrms25@Center.com")]
        [System.ComponentModel.DataAnnotations.Required]
        public string Email { get; set; }
        [MaxLength(100,ErrorMessage ="Subject not mor than 100 Char")]
        [Required]
        public string Subject { get; set; }

        [MaxLength(500,ErrorMessage = "Message not mor than 500 Char")]
        [Required]

        public string? Message { get; set; }

    }
}
