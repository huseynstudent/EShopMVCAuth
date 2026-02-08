using Microsoft.AspNetCore.Identity;

namespace EShopp.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
