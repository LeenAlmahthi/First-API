using System;
using Domain.entity;
public class CreateStudent
{
	private readonly IStudentRepository _IStudentRepository;
    public CreateStudent(IStudentRepository iStudentRepository)
	{
		_IStudentRepository = iStudentRepository;
        // validation 
    }
	public Students create(Students s)
	{
        // validation 
        return (_IStudentRepository.createStudent(s));
    }
}
