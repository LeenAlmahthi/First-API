using System;
using Domain.entity;
public interface ICourseRepository
{
    public bool check_course_students_sameMatrial();
    public bool check_course_students_sameTime();
 //   public ICourseRepository()
	//{
	//}
}
