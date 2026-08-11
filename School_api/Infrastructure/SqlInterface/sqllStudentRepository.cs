using System;
using Domain.entity;
using Domain.entity.course;
using School_api.Data;
using Domain.Validation_;
public class sqlIStudentRepository : IStudentRepository
    {
        private readonly DataContext Data;
        public sqlIStudentRepository(DataContext _Data)
        {
            Data = _Data;
        }
       public List<Students> getAllStudents()
        {
            var students = Data.Students.ToList();
            if (students == null)
                throw new Exception("No students found.");
            return students;
        }
    }