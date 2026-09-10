
using System;
using Domain.entity;
using Domain.entity.course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using School_api.Data;

[ApiController]
[Route("[Controller]")]
public class AvaliableCourseController : ControllerBase
{
	private readonly CreateAvalibleCourse createCourse;
	//private readonly DeleteCourse deleteCourse;
	//private readonly ShowCourse showCourse;
    
    //public CourseController(CreateCourse _createCourse, DeleteCourse _deleteCourse, ShowCourse _ShowCourse)
    public AvaliableCourseController(CreateAvalibleCourse _createCourse)
	{
		createCourse = _createCourse;
		//deleteCourse = _deleteCourse;
		//showCourse = _ShowCourse;
    }
	[HttpPost]
    //[Authorize(Roles = "student")]
    public IActionResult PostCourse(AvailableCourse course)
	{
		try
		{
            //_student.
            // Implement this method to retrieve the student from the request context
            //Console.WriteLine($"Received course: {course.Id}, {course.SectionId}, {course.Name}, {course.DoctorId}, {course.CourseTime}, {course.Price}");

            if (createCourse.PostAvailableCourse(course))
            {
                return Ok("Course created successfully.");
            }
            else
            {
                return BadRequest("Failed to create course.");
            }
        }
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal server error: {ex.Message}");
		}
    }
	//[HttpDelete]
 //   [Authorize(Roles = "student")]
 //   public IActionResult Delete(int id)
	//{
	//	deleteCourse.Delete(id);
	//	return Ok("Delete Done");

 //   }
	//[HttpGet]
	//public IActionResult Show()
	//{
	//	var re = showCourse._ShowCourse();
	//	if (re == null)
	//		return NotFound();
	//	return Ok(re);

 //   }
}
