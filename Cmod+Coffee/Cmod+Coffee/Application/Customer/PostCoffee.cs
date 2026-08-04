using Cmod_Coffee.Application.Customer;
using Cmod_Coffee.Domain;
using Cmod_Coffee.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace Cmod_Coffee.Application.custtomer
{
    public class PostCoffee
    {
        private readonly ICoffeeRepository ICustomer;
        private readonly OrderValidator _role;
        public PostCoffee(ICoffeeRepository Idata, OrderValidator role)
        {
            ICustomer = Idata;
            _role = role;
        }      
        public CoffeeOrder? Post(CoffeeOrder info_)
        {
            if (!_role.ValidateOrder(info_))
                return (null);
            ICustomer.Add(info_);


            return (info_);
        }
    }
}
