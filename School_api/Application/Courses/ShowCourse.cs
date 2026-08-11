using System;
using Domain.entity.course;
public class ShowCourse
{
	private readonly ICourseRepository _ICourseRepository;
	public ShowCourse(ICourseRepository iCourseRepository)
	{
		_ICourseRepository = iCourseRepository ;
	}
	public List<Course>? _ShowCourse()
	{
		return (_ICourseRepository.Show());
    }
}