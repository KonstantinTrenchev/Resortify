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
        public DbSet<Accomodation> Accomodations { get; init; }
        public DbSet<Photo> Photos { get; init; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Rent> Rents { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                    .Entity<Accomodation>()
                    .HasOne(a => a.Owner)
                    .WithMany(o => o.Accomodations)
                    .HasForeignKey(c => c.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Photo>()
                .HasOne(p => p.Accomodation)
                .WithMany(a => a.Photos)
                .HasForeignKey(p => p.AccomodationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Owner>()
                .HasOne<ResortifyUser>()
                .WithOne()
                .HasForeignKey<Owner>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Rent>()
                .HasOne(r => r.Accomodation)
                .WithMany(a => a.AccomoditionRents)
                .HasForeignKey(r => r.AccomodationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}