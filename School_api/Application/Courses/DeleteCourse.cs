using System;

public class DeleteCourse
{
	private readonly ICourseRepository _courseRepository;
    public DeleteCourse(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
    }
	public void Delete(int id)
	{
		// Don't have role to delete a course :(
		_courseRepository.DeleteCourse(id);
    }
}
