using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Resortify.Data.Models;

namespace Resortify.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<ResortifyUser> Users { get; set; }
        public DbSet<Accomodation> Accomodations { get; init; }
        public DbSet<Comment> Comments { get; init; }
        public DbSet<Rent> Rents { get; set; }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Server=KOKO-DESKTOP\\SQLEXPRESS;Database=Resortify;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RoleManager<ApplicationDbContext> roleManager;
            
           base.OnModelCreating(builder);
    }
}
}