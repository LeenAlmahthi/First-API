//using School_api.Data;
using Domain.entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using School_api.Data;
//using School_api.Model;

namespace School_api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentsController : Controller
    {
        public DataContext data { get; set; }
        public StudentsController(DataContext DB)  
        {
            data = DB;
        }
        /// <summary>
        /// xml decumention 
        /// error handle 
        /// arthercter  (injection )
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "student")]
        public IActionResult get_Student()
        {
            var tmp = data.Students.ToList();
            if (tmp == null)
                return NotFound();
            return Ok(tmp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize (Roles = "student")]
        public IActionResult get_Student(int id)
        {
            var tmp = data.Students.Find(id);
            if (tmp == null)
                return NotFound();
            return Ok(tmp);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult post_Student(Students s)
        {
            if (s == null)
                return NotFound();
            data.Students.Add(s);
            data.SaveChanges();
            return Ok(s);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult update_student(int id ,Students s)
        {
            if (s == null)
                return NotFound();
            var q = data.Students.Find(id);
            if (q == null)
                return NotFound();
            q.Id = id;
            q.FirstName = s.FirstName;
            //q.Age = s.Age;
            data.SaveChanges();
            return Ok(q);

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult delete_student(int id)
        {
            var q = data.Students.Find(id);
            if (q == null)
                return NotFound();
            data.Remove(q);
            data.SaveChanges();
            return Ok();

        }
    }
}
