using System;
using Domain.entity;
using Domain.entity.course;
using School_api.Data;
using Domain.Validation_;
public class sqlICourseRepository : ICourseRepository
{
    private readonly DataContext Data;
    private readonly Validation validation;
    public sqlICourseRepository(DataContext _Data, Validation _validation)
    {
        Data = _Data;
        validation = _validation;
    }
    public bool check_course_students_sameMatrial(int id, string NameCourse)
    {
        var student = Data.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
            throw new Exception("Student not found.");
        var courses = Data.Courses.Where(c => c.Name == NameCourse).ToList();
        if (courses.Count == 0)
            throw new Exception("Course not found.");
        foreach (var q in courses)
        {
            if (q.Name == NameCourse)
                return false;
        }
        return true;
    }
    public bool check_course_students_sameTime(int id, TimeOnly time)
    {
        var student = Data.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
            throw new Exception("Student not found.");
        var courses = Data.Courses.Where(c => c.CourseTime == time).ToList();
        if (courses.Count == 0)
            throw new Exception("Course not found.");
        foreach (var q in courses)
        {
            if (q.CourseTime == time)
                return false;
        }
        return true;
    }
    public void AddCourse(Course course)
    {
        if (course == null)
            throw new ArgumentNullException(nameof(course));
        //if (validation.ValidateCourse())

        Data.Courses.Add(course);
        Data.SaveChanges();
    }
}