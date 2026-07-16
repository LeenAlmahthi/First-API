using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_api.Model;
using School_api.Data;
namespace School_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class authApplication :Controller
    {
        private DataContext data;
        authApplication(DataContext q)
        {
                data = q;
        }

        [HttpPost]
        public IActionResult login(ApplicationUser UserData)
        {
            var q = data.students.ToList();
            //data.UserLogins.ID = USerData.Id
            //Console.WriteLine(returnUrl);
            return Ok(data);
        }
    }
}
