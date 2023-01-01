using Graduation_Project.Models;
using Microsoft.AspNetCore.Identity;
using Graduation_Project.AdminRepository;
using Graduation_Project.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CenterDBContext>
    (
        n => 
    { n.UseSqlServer("Server=.;Database=finalDb;Trusted_Connection=True;"); }
    );
builder.Services.AddIdentity<Account,IdentityRole>().AddEntityFrameworkStores<CenterDBContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISubjectRepositry, SubjectRepositry>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IStudentRepositry, StudentRepositry>();
builder.Services.AddScoped<IRegisterRepositry, RegisterRepositry>();
builder.Services.AddScoped<ITeacherRepositry, TeacherRepositry>();
builder.Services.AddScoped<IContactusRepositry,ContactsusRepositry>();
builder.Services.AddScoped<IRegister, RegisterRepository>();
builder.Services.AddScoped<IContactUs, ContactUsRepository>();
builder.Services.AddScoped<IGroup, GroupRepository>();
builder.Services.AddScoped<ISubject, SubjectRepository>();
builder.Services.AddScoped<ITeacher, TeacherRepository>();
builder.Services.AddScoped<IStudent,Graduation_Project.AdminRepository.StudentRepository >();
builder.Services.AddScoped<IAssignStudentsGroup, AssignStudentsGroupRepository>();
    
builder.Services.AddScoped<IPostRepository , PostRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "areas",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
