using System;
using Domain.entity.course;

public class CreateCourse
{
	private readonly ICourseRepository Icoures;
    public CreateCourse(ICourseRepository _Icoures)
	{
		Icoures = _Icoures;
    }
	public bool PostCourse(Course course)
	{
		if (course == null)
		{
			throw new ArgumentNullException(nameof(course));
		}
		Icoures.AddCourse(course);
		return true;
    }
}
