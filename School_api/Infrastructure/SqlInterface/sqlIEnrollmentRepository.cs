using System;
using School_api.Data;
using System;
using Domain.entity;
using Domain.entity.course;
using School_api.Data;
using Domain.Validation_;
using Domain.entity;

public class sqlIEnrollmentRepository : IEnrollmentRepository
{
	private readonly DataContext _data;
    public sqlIEnrollmentRepository(DataContext data)
	{
		_data = data;
    }
    public int createEnrollment(Students students, Course course)
    {
        if (students == null || course == null)
            throw new ArgumentNullException("Students or Course cannot be null.");

        var enrollment = new Enrollment();
        enrollment.IdStudent = students.Id;
        enrollment.IdCourse = course.Id;
        enrollment.NameStudent = students.FirstName;
        enrollment.NameCourse = course.Name;
        _data.Enrollments.Add(enrollment);
        _data.SaveChanges();
        return enrollment.Id;
    }
}
