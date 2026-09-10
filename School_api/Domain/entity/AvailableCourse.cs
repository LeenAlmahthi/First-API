using System;
namespace Domain.entity.course;

public class AvailableCourse
{
	public int Id { get; set; }
    public int SectionId { get; set; }
    public string Name { get; set; }
	public string DoctorId { get; set; }
	public TimeOnly CourseTime { get; set; }
	public double Price { get; set; }
}