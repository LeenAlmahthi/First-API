using System;
using Domain.entity;
public class ShowStudents
{
	private readonly IStudentRepository _IStudentRepository;
    public ShowStudents(IStudentRepository iStudentRepository)
	{
		_IStudentRepository = iStudentRepository;
	}
	public List<Students> show()
	{
		var tmp = _IStudentRepository.getAllStudents();
		if (tmp == null)
			return new List<Students>();
		return tmp;
    }
}
