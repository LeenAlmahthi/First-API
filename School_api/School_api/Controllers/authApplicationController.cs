using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using School_api.Model;
using School_api.Data;
using School_api.Register;
namespace School_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class authApplication : ControllerBase
    {
        private DataContext data;
        private UserManager<ApplicationUser> users;
        public authApplication(UserManager<ApplicationUser> App_user, DataContext data_context)
        {
            users = App_user;
            data = data_context;
        }
        [HttpPost("Register")]
        public  async Task<IActionResult> Register(register UserData)
        {
            var q = new ApplicationUser();
            q.UserName = UserData.Username;
            q.Email = UserData.Email;
            var _user = await users.CreateAsync(q, UserData.Password);
            return Ok(_user);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(register login)
        {
            if (login == null)
                return NotFound();
            var q = await users.FindByNameAsync(login.Username);
            if (q == null)
                return Unauthorized("user name not found");
            var pass = await users.CheckPasswordAsync(q, login.Password);
            if (!pass)
                return Unauthorized("user name not found");
            return Ok("Login seccsuesful");

        }
    }
}
