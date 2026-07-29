using Cmod_Coffee.Application.Customer;
using Cmod_Coffee.Infrastructure;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace Cmod_Coffee.Infrastructure
{
    public class SqlCoffeeRepository : ICoffeeRepository
    {
        private readonly DataContext DataCustomer;

        public SqlCoffeeRepository(DataContext data)
        {
            DataCustomer = data;
        }
        public CoffeeOrder Add(CoffeeOrder coffeeOrder)
        {
            var coffee = new CoffeeOrder();
            coffee.Name = coffeeOrder.Name;
            coffee._coffeeType = coffeeOrder._coffeeType;
            coffee.SizeCap = coffeeOrder.SizeCap;
            coffee.Price = coffeeOrder.Price;
            DataCustomer.Data.Add(coffee);
            DataCustomer.SaveChanges();
            return coffee;
        }
        public string _Delete(int id)
        {
            var order = DataCustomer.Data.Find(id);
            if (order == null)
                return (string.Empty);
            DataCustomer.Data.Remove(order);
            DataCustomer.SaveChanges();
            return ("Order Deleted");
        }
        public CoffeeOrder? GetById(int id)
        {
            var order = DataCustomer.Data.Find(id);
            return (order);
        }
        public List<CoffeeOrder>? GetAll()
        {
            var order = DataCustomer.Data.ToList();
            return (order);
        }
    }
}
