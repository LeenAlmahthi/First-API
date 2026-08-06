using System;
using Domain.entity;
public class ValidationPayment
{
	private readonly Payment payment;
    public ValidationPayment(Payment _payment)
	{
		payment = _payment;
    }
	public bool Validate()
	{
		if (string.IsNullOrWhiteSpace(payment.Name))
		{
			return false;
		}
		if (payment.Amount <= 0)
		{
			return false;
		}
		return true;
    }
}
