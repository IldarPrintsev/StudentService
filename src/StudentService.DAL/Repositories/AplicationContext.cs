using Microsoft.EntityFrameworkCore;
using StudentService.DAL.Models;

namespace StudentService.DAL.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
    }
}
