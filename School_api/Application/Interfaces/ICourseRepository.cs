using System;
using Domain.entity;
using Domain.entity.course;
public interface ICourseRepository
{
    public void AddCourse(Course course);
    public bool check_course_students_sameMatrial(int id, string NameCourse);
    public bool check_course_students_sameTime(int id, TimeOnly time);
}