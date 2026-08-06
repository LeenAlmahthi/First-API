using System;
using Domain.Validation;
using Domain.entity.course;
using Domain.entity;
namespace Domain.Validation_;
public class Validation
{
	private readonly ValidationConfuseCourseStudents Valid;
    public Validation(ValidationConfuseCourseStudents _Valid)
	{
		Valid = _Valid;
    }
	public bool ValidateCourse(Course course, Students student)
	{
		return Valid.Validate(course, student);
    }

}
