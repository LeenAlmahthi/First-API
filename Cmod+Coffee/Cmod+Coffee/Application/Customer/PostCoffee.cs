using Cmod_Coffee.Application.Customer;
using Cmod_Coffee.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace Cmod_Coffee.Application.custtomer
{
    public class PostCoffee
    {
        private readonly ICoffeeRepository ICustomer;
        public PostCoffee(ICoffeeRepository Idata)
        {
            ICustomer = Idata;
        }

        

        public CoffeeOrder Post(CoffeeOrder info_)
        {
            ICustomer.Add(info_);
          
            return (info_);
        }
    }
}
