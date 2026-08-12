using System;
using Domain.entity.course;
namespace Domain.entity;
public class CreateEnrollmentRequest
{
    public Students Student { get; set; }
    public Course Course { get; set; }
}
