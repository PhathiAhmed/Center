using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Models
{
    public class CenterDBContext:IdentityDbContext
    {
        public CenterDBContext()
        {

        }
        public CenterDBContext(DbContextOptions options) :base(options)
        {

        }
       
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //        modelBuilder.Entity<StudentSubjectGroupTeacher>()
        //        .HasKey("StudentId", "SubjectId", "TeacherId", "GroupId");
        //    //modelBuilder.Entity<IdentityUserLogin>().HasNoKey();
        //    //modelBuilder.Entity<IdentityUserLogin>(
        //    //eb =>
        //    //{
        //    //    eb.HasNoKey();
        //    //});
        //    base.OnModelCreating(modelBuilder);

        //}

        public  DbSet<Account> Accounts { get; set; }
        public  DbSet<Admin> Admins { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        //public DbSet<StudentSubjectGroupTeacher> StudentsSubjectsGroupsTeachers { get; set; }



    }
}
