using System;
using Domain.entity.course;
using Domain.entity;
namespace Domain.Validation;
public class ValidationConfuseCourseStudents
{
	public readonly ICourseRepository _courseRepository;
	public ValidationConfuseCourseStudents(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
    }
    public bool Validate(Course course, Students student)
	{
		if (_courseRepository.check_course_students_sameMatrial(student.Id ,course.Name) || _courseRepository.check_course_students_sameTime(student.Id, course.CourseTime))
			throw new Exception("There is a conflict between the courses and the students.");
		return true;
    }
}
