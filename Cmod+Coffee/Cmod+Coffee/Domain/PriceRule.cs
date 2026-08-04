using Cmod_Coffee.Infrastructure;

namespace Cmod_Coffee.Domain
{
    public class PriceRule
    {
        public bool CheckValidation(double Price)
        {
            if (Price <= 0)
                return false; 
            else
                return true;
        }
    }
}
