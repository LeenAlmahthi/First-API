using Cmod_Coffee.Infrastructure;

namespace Cmod_Coffee.Application.Customer
{
    public interface ICoffeeRepository
    {
        CoffeeOrder Add(CoffeeOrder coffeeOrder);
        string _Delete (int id );
        CoffeeOrder? GetById(int id);
        List<CoffeeOrder>? GetAll();
        //void Delete(int id);

    }
}
