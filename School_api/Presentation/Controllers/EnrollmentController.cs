using System;
using Domain.entity;
using Domain.entity.course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using School_api.Data;

[ApiController]
[Route("[Controller]")]
public class EnrollmentController : ControllerBase
{
    private readonly CreateEnrollment createEnrollment;
    //private readonly DeleteCourse deleteCourse;
    //private readonly ShowCourse showCourse;

    public EnrollmentController(CreateEnrollment _createEnrollment)
    {
        createEnrollment = _createEnrollment;

    }
    [HttpPost]
    public IActionResult Post(CreateEnrollmentRequest request)
    {
        try
        {
            int enrollmentId = createEnrollment.create(request.Student, request.Course);
            return Ok($"Enrollment created successfully with ID: {enrollmentId}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }
    //[HttpDelete]
    //public IActionResult Delete(int id)
    //{
    //    deleteCourse.Delete(id);
    //    return Ok("Delete Done");

    //}
    //[HttpGet]
    //public IActionResult Show()
    //{
    //    var re = showCourse._ShowCourse();
    //    if (re == null)
    //        return NotFound();
    //    return Ok(re);

    //}
}
