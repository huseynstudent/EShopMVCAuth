using AspnetMvcAuth.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspnetMvcAuth.Context;

public class AcademyDbContext : IdentityDbContext<ApplicationUser>
{
    public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
    {
    }

}
