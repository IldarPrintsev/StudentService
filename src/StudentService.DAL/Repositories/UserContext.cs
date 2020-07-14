using Microsoft.EntityFrameworkCore;
using StudentService.DAL.Models;

namespace StudentService.DAL.Repositories
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "user",
                    Password = "111",
                    Role = "User"
                },
                new User
                {
                    Id = 2,
                    UserName = "admin",
                    Password = "222",
                    Role = "Admin"
                },
                new User
                {
                    Id = 3,
                    UserName = "manager",
                    Password = "333",
                    Role = "Manager"
                });
        }
    }
}
