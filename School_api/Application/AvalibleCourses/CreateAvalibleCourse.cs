using System;
using Domain.entity.course;

public class CreateAvalibleCourse
{
	private readonly IAvailableCourseRepository Icoures;
    public CreateAvalibleCourse(IAvailableCourseRepository _Icoures)
	{
		Icoures = _Icoures;
    }
    public bool PostAvailableCourse(AvailableCourse course)
	{
		if (course == null)
		{
			throw new ArgumentNullException(nameof(course));
		}
        Icoures.AddCourse(course);
		return true;
    }
}
