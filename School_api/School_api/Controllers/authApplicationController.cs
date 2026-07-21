using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using School_api.Model;
using School_api.Data;
using School_api.Register;
using School_api._login;
namespace School_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class authApplication : ControllerBase
    {
        private DataContext data;
        private UserManager<ApplicationUser> _usermanager;
        public authApplication(UserManager<ApplicationUser> App_user, DataContext data_context)
        {
            _usermanager = App_user;
            data = data_context;
        }

        [HttpPost("Register")]
        public  async Task<IActionResult> Register(register userBody)
        {
            if (userBody == null)
                return BadRequest("request is empty");
            var user = new ApplicationUser();
            var admin = await _usermanager.FindByNameAsync("Admin");
            if (admin == null)
            {
                user.UserName = "Admin";
                user.Email = userBody.Email;
                var Pass = await _usermanager.CreateAsync(user,userBody.Password);
                if (Pass == null)
                    return BadRequest("can't add Admin");
                //await _usermanager.AddToRoleAsync(user, "Admin");
                var roleResult = await _usermanager.AddToRoleAsync(user, "Admin");

                if (!roleResult.Succeeded)
                {
                    return BadRequest(roleResult.Errors);
                }
                return Ok("Create Admin");

            }
            user.UserName = userBody.Username;
            user.Email = userBody.Email;
            var pass = await _usermanager.CreateAsync(user, userBody.Password);
            if (pass == null)
                    return NotFound("not allow this Passwords");
            await _usermanager.AddToRoleAsync(user,"student");
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login_user(Login login)
        {
            if (login == null)
                return NotFound();
            var user = await _usermanager.FindByNameAsync(login.UserName);
            if (user == null)
                return Unauthorized("user name not found");
            var pass = await _usermanager.CheckPasswordAsync(user, login.Password);
            if (!pass)
                return Unauthorized("Can't Login try Again");
            //return Ok("Login seccsuesful");
            return Ok(GenerateJwt.CreateJwt(user));
        }
        [HttpDelete("Account")]
        public async Task<IActionResult> DeleteAccount(register _user)
        {
            var user = await _usermanager.FindByNameAsync(_user.Username);
            if (user == null)
                return NotFound("Not Found");
            var re = await _usermanager.DeleteAsync(user);
            if (!re.Succeeded)
                return BadRequest("delete is empty");
            return Ok("Seccsuesful Delete Account");          
        }
    }
}
