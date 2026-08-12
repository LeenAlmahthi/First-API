using System;
using School_api.Data;
using System;
using Domain.entity;
using Domain.entity.course;
using School_api.Data;
using Domain.Validation_;
using Domain.entity;
public interface IEnrollmentRepository
{
    public int createEnrollment(Students students, Course course);
}
