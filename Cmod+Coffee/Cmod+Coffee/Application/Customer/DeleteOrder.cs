namespace Cmod_Coffee.Application.Customer
{
    public class DeleteOrder
    {
        private readonly ICoffeeRepository ICustomer;
        public DeleteOrder(ICoffeeRepository Idata)
        {
            ICustomer = Idata;
        }
        public  string _DeleteOrder(int id)
        {
            //  busineeslogic  add here 
            return (ICustomer._Delete(id));
        }
    }
}
