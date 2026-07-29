using Cmod_Coffee.Infrastructure;

namespace Cmod_Coffee.Application.Customer
{
    public class GetOrder
    {
        private readonly ICoffeeRepository Icustomer;
        public GetOrder(ICoffeeRepository _Icustomer)
        {
            Icustomer = _Icustomer;
        }
        public CoffeeOrder GetById(int id)
        {
            return (Icustomer.GetById(id));
        }
        public List<CoffeeOrder> GetAll()
        {
            List<CoffeeOrder>? re = Icustomer.GetAll();
            if (re == null)
                return (re);
            return (re);
        }

    }
}
