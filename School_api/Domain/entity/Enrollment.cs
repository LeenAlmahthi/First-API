using System;
namespace Domain.entity
{
	public class Enrollment
    {
		public int Id { get; set; }
		public int IdStudent { get; set; }
		public int IdCourse { get; set; }
		public string NameCourse { get; set; }
		public string NameStudent { get; set; }
    }
}