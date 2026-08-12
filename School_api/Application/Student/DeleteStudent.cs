using System;
using Domain.entity;
public class DeleteStudent
{
	private readonly IStudentRepository _IStudentRepository;
    public DeleteStudent(IStudentRepository iStudentRepository)
	{
		_IStudentRepository = iStudentRepository;
        // validation 
    }
    public Students? delete(int id)
    {
        // validation 
        return (_IStudentRepository.deleteStudent(id));
    }
}
