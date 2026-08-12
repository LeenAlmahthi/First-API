using System;
using Domain.entity;
using Domain.entity.course;
using School_api.Data;
using Domain.Validation_;
using Domain.entity;
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
    public Students? createStudent(Students s)
    {
        if (s == null)
            return null;
        Students re = new Students();
        re.Id = s.Id;
        re.FirstName = s.FirstName;
        re.LastName = s.LastName;
        re.Email = s.Email;
        re.Phone = s.Phone;
        re.Major = s.Major;

        Data.Students.Add(re);
        Data.SaveChanges();
        return re;
    }
    public Students? deleteStudent(int id)
    {
        var re = Data.Students.Find(id);
        if (re == null)
            return null;
        Data.Students.Remove(re);
        Data.SaveChanges();
        return re;
    }
}