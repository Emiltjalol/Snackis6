using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Snackis6.Areas.Identity.Data;
using Snackis6.Models;

namespace Snackis6.Data;

public class Snackis6Context : IdentityDbContext<Snackis6User>
{
    public Snackis6Context(DbContextOptions<Snackis6Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<Snackis6.Models.Message> Message { get; set; } = default!;
public DbSet<Snackis6.Models.Category> Category { get; set; } = default!;
public DbSet<Snackis6.Models.Subcategory> subcategory { get; set; } = default!;
public DbSet<Snackis6.Models.Post> Post { get; set; } = default!;
public DbSet<Snackis6.Models.Comment> Comment { get; set; } = default!;
public DbSet<Snackis6.Models.Reported> Reported { get; set; } = default!;

}
