using System;
using System.ComponentModel.DataAnnotations;
namespace Domain.entity;

public class Students
{
	public int Id { get; set; }
	[Required]
	[MaxLength(20)]
	public string FirstName { get; set; }
	public string LastName { get; set; } = string.Empty;
	public string Email { get; set; }
	public string Major { get; set; }
	public string Phone { get; set; }
}
