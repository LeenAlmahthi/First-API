using System;
using Domain.entity;

public interface IStudentRepository
{
	//    public IStudentRepository()
	//	{
	//	}
	public List<Students> getAllStudents();
	public Students? createStudent(Students s);
}
