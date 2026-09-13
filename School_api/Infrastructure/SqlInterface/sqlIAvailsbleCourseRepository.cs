using System;
using Domain.entity;
using Domain.entity.course;
using School_api.Data;
using Domain.Validation_;
namespace sqlICourse
{
    public class sqlIAvailsbleCourseRepository : IAvailableCourseRepository
    {
        private readonly DataContext Data;
        public sqlIAvailsbleCourseRepository(DataContext _Data)
        {
            Data = _Data;
        }
    
         public void AddCourse(AvailableCourse course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            Console.WriteLine(
                $"Course: Id={course.Id}, " +
                $"SectionId={course.SectionId}, " +
                $"Name={course.Name}, " +
                $"DoctorId={course.DoctorId}, " +
                $"CourseTime={course.CourseTime}, " +
                $"Price={course.Price}"
            );

            try
            {
                Data.Avaliblecourses.Add(course);
                Data.SaveChanges();

                Console.WriteLine("COURSE SAVED SUCCESSFULLY!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("========== DATABASE ERROR ==========");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("====================================");

                throw;
            }
        }
        //            if (course == null)
        //                throw new ArgumentNullException(nameof(course));
        //            Console.WriteLine(
        //$"In controller: Id={course.Id}, " +
        //$"SectionId={course.SectionId}, " +
        //$"Name={course.Name}, " +
        //$"DoctorId={course.DoctorId}, " +
        //$"CourseTime={course.CourseTime}, " +
        //$"Price={course.Price}"
        //);
        //   Data.Avaliblecourses.Add(course);
        //            Data.SaveChanges();

        //public void DeleteCourse(int id) { 

        //}
        //public List<AvailableCourse>? Show() { 
        //}
        //public void AddCourse(Course course)
        //{
        //    if (course == null)
        //        throw new ArgumentNullException(nameof(course));
        //    //if (validation.ValidateCourse())

        //    Data.Courses.Add(course);
        //    Data.SaveChanges();
        //}
        public void DeleteCourse(int id)
        {
            var course = Data.Avaliblecourses.Find(id);
            if (course == null)
                throw new Exception("Course not found.");
            Data.Avaliblecourses.Remove(course);
            Data.SaveChanges();
            Console.WriteLine($"Course with ID {id} has been deleted successfully.");
        }

        public List<AvailableCourse>? Show()
        {
            var course = Data.Avaliblecourses.ToList();
            if (course == null)
                return null;
            foreach (var c in course)
            {
                Console.WriteLine(
                    $"Course: Id={c.Id}, " +
                    $"SectionId={c.SectionId}, " +
                    $"Name={c.Name}, " +
                    $"DoctorId={c.DoctorId}, " +
                    $"CourseTime={c.CourseTime}, " +
                    $"Price={c.Price}"
                );
            }
            return (course);
        }
    }
}