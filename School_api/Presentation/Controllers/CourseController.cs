
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
    public CourseController(CreateCourse _createCourse)
	{
		createCourse = _createCourse;
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
}
