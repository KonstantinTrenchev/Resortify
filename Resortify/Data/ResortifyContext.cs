using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Resortify.Data;

public class ResortifyContext : IdentityDbContext<ResortifyUser>
{
    public ResortifyContext(DbContextOptions<ResortifyContext> options)
        : base(options)
    {
    }
    public DbSet<ResortifyUser> Users { get; init; }
    public DbSet<Accomodation> Accomodations { get; init; }
    public DbSet<Photo> Photos { get; init; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
