using System;
using Domain.entity;
using Domain.entity.course;


public class CreateEnrollment
{
    private readonly IEnrollmentRepository _IEnrollmentRepository;
    public CreateEnrollment(IEnrollmentRepository iEnrollmentRepository)
    {
        _IEnrollmentRepository = iEnrollmentRepository;
        // validation 
    }
    public int create(Students students, Course course)
    {
        // validation 
        return (_IEnrollmentRepository.createEnrollment(students, course));
    }
}
