using System;
using Domain.entity;
using Domain.entity.course;
public interface IAvailableCourseRepository
{
    public void AddCourse(AvailableCourse course);
    //public void DeleteCourse(int id);
    //public List<AvailableCourse>? Show();

}