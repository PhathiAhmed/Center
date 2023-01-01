using System.ComponentModel.DataAnnotations;
using Graduation_Project.Models;
namespace Graduation_Project.ViewModels
{
    public class LoginVM
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
