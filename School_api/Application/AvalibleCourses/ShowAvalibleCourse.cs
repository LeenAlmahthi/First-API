using System;
using Domain.entity.course;
public class ShowAvalibleCourse
{
    private readonly IAvailableCourseRepository _ICourseRepository;
    public ShowAvalibleCourse(IAvailableCourseRepository iCourseRepository)
    {
        _ICourseRepository = iCourseRepository;
    }
    public List<AvailableCourse>? _ShowCourse()
    {
        return (_ICourseRepository.Show());
    }
}