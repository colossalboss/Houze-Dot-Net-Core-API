using System;
using HouzeAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HouzeAPI.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {
            //, IDesignTimeDbContextFactory<AppDbContext>
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        //public AppDbContext CreateDbContext(string[] args)
        //{
        //    throw new NotImplementedException();
        //}

        //public AppDbContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        //    //optionsBuilder.UseMySql("Server=localhost;DataBase.....");
        //    //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=username;Password=secret;Database=todos;");

        //    return new AppDbContext(optionsBuilder.Options);
        //}
    }
}
