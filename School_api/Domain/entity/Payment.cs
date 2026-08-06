using System;
namespace Domain.entity;
public class Payment
{
	public int Id { get; set; }
	public string Name { get; set; }
	public double Amount { get; set; }
    public Payment()
	{
	}
}
