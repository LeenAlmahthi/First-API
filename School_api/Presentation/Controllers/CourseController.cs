
using System;
using Domain.entity;
using Domain.entity.course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using School_api.Data;

[ApiController]
[Route("[Controller]")]
public class CourseController : ControllerBase
{
	private readonly CreateCourse createCourse;
	private readonly DeleteCourse deleteCourse;
	private readonly ShowCourse showCourse;
    
    public CourseController(CreateCourse _createCourse, DeleteCourse _deleteCourse, ShowCourse _ShowCourse)
	{
		createCourse = _createCourse;
		deleteCourse = _deleteCourse;
		showCourse = _ShowCourse;

}
	[HttpPost]
	public IActionResult PostCourse(Course course)
	{
		try
		{
			 Students _student = new Students(); // Assuming you have a way to get the student object
			_student.Id = 5;
            //_student.
			// Implement this method to retrieve the student from the request context
            if (createCourse.PostCourse(course))
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
	[HttpDelete]
	public IActionResult Delete(int id)
	{
		deleteCourse.Delete(id);
		return Ok("Delete Done");

    }
	[HttpGet]
	public IActionResult Show()
	{
		var re = showCourse._ShowCourse();
		if (re == null)
			return NotFound();
		return Ok(re);

    }
}
