using System;
using Domain.entity;
using Domain.entity.course;
using School_api.Data;
using Domain.Validation_;
namespace sqlICourse
{
    public class sqlIAvailsbleCourseRepository : IAvailableCourseRepository
    {
        private readonly DataContext Data;
        public sqlIAvailsbleCourseRepository(DataContext _Data)
        {
            Data = _Data;
        }
        public void AddCourse(AvailableCourse course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));
            Data.Avaliblecourses.Add(course);
            Data.SaveChanges();
        }
        //public void DeleteCourse(int id) { 
        
        //}
        //public List<AvailableCourse>? Show() { 
        //}
        //public void AddCourse(Course course)
        //{
        //    if (course == null)
        //        throw new ArgumentNullException(nameof(course));
        //    //if (validation.ValidateCourse())

        //    Data.Courses.Add(course);
        //    Data.SaveChanges();
        //}
        //public void DeleteCourse(int id)
        //{
        //    var course = Data.Courses.Find(id);
        //    if (course == null)
        //        throw new Exception("Course not found.");
        //    Data.Courses.Remove(course);
        //    Data.SaveChanges();
        //    Console.WriteLine($"Course with ID {id} has been deleted successfully.");
        //}

        //public List<Course>? Show()
        //{
        //    var course = Data.Courses.ToList();
        //    if (course == null)
        //        return null;
        //    return (course);
        //}
    }
}