using System;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Concrete
{
    public class Context:DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=111.111.111.11;database=databasename;User Id=mseker;Password=mypassword!;Encrypt=True;TrustServerCertificate=True;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        
    }
}
