using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TestWebApplication.Models;

namespace TestWebApplication
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //            new User { Id = 1, Name = "Tom", DateOfBirth = DateTime.Now },
        //            new User { Id = 2, Name = "Bob", DateOfBirth = DateTime.Now },
        //            new User { Id = 3, Name = "Sam", DateOfBirth = DateTime.Now }
        //    );
        //}
    }
}
