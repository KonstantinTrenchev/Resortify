using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resortify.Data.Models;

namespace Resortify.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ResortifyUser> Users { get; set; }
        public DbSet<Accomodation> Accomodations { get; init; }
        public DbSet<Comment> Comments { get; init; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Rent> Rents { get; set; }
        //public DbSet<OwnerAccomodation> OwnerAccomodations { get; set; }
        //public DbSet<AccomodationComment> AccomodationComments { get; set; }
        //public DbSet<AccomodationRent> AccomodationRents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            //builder
            //    .Entity<ResortifyUser>()
            //    .HasOne<Owner>()
            //    .WithOne(o => o.User)
            //    .HasForeignKey<Owner>(o => o.UserId);


            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}