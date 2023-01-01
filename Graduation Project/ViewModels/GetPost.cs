using Graduation_Project.Models;

namespace Graduation_Project.ViewModels;
public class GetPost
{
    public int PostId { get; set; }
    public string PostMakerName { get; set; }
    public string PostMakerImage { get; set; }
    public int PostMakerId { get; set; }
    public DateTime PostDate { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public int likes { get; set; }
    public List<Comment> comments { get; set; }
    //public IFormFile File { get; set; }
}
