using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EShopp.DAL.Context;

public class EShoppDbContext : IdentityDbContext<ApplicationUser>
{
    public EShoppDbContext(DbContextOptions<EShoppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
}