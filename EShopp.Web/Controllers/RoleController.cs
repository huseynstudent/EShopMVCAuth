using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShopp.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest("Role name cannot be empty.");

            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                    return StatusCode(500, "Failed to create role.");
            }

            return Ok($"Role '{roleName}' ensured.");
        }
    }
}
