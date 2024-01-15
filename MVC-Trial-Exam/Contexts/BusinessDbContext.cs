using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Trial_Exam.Models;

namespace MVC_Trial_Exam.Contexts
{
    public class BusinessDbContext : IdentityDbContext<AppUser>
    {
        public BusinessDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AppUser> Users {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
