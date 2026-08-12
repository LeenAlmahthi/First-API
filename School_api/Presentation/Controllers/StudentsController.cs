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
        private readonly ShowStudents showStudents; 
        private readonly CreateStudent createStudent; 
        private readonly DeleteStudent deleteStudent;
        public StudentsController(ShowStudents _ShowStudents, CreateStudent _createStudent, DeleteStudent _deleteStudent)
        {
            showStudents = _ShowStudents;
            createStudent = _createStudent;
            deleteStudent = _deleteStudent;
        }
        [HttpGet]
        public IActionResult get_Student()
        {
            return Ok(showStudents.show());
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult post_Student(Students s)
        {
            if (s == null)
                return NotFound();
            var re = createStudent.create(s);
            if (re == null)
                return NotFound();
            return Ok(re);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult delete_student(int id)
        {
            var re = deleteStudent.delete(id);
            if (re == null)
                return NotFound();
            return Ok(re);
        }
    }
}
