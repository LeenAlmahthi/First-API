using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace School_api.role
{
    public class SeedData
    {
        //This is a class from the ASP.NET Core Identity librar
        // role are name attribute in the calss IdentityRole
        public static async Task SeedRoles(RoleManager<IdentityRole> _role)
        {
            if (!await _role.RoleExistsAsync("Admin"))
                await _role.CreateAsync(new IdentityRole("Admin"));
            if (!await _role.RoleExistsAsync("student"))
                await _role.CreateAsync(new IdentityRole("student"));
        }
    }
}