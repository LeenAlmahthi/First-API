using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.entity;
namespace School_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class authApplication : ControllerBase
    {
        private SignIn login;
        private Delete delete_account; 
        private SignUp register; 
        public authApplication( SignUp _register, SignIn _login, Delete _delete)
        {
            login = _login;
            delete_account = _delete;
            register = _register;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(register userBody)
        {
             var re = await  register.signup(userBody);
            return Ok(re);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> post(Login user)
        {
            var re = await login.LoginAccount(user);
            return Ok(re);
        }
        [HttpDelete("Account")]
        public async Task<IActionResult> remove_user(DeleteAccount user)
        {
            var re = await delete_account.remove_user(user);
            return Ok(re);
        }
    }
}
