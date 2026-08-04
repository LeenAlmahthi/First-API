using Cmod_Coffee.Infrastructure;
namespace Cmod_Coffee.Domain
{
    public class OrderValidator
    {
        private readonly SizeRule _sizeRule;
        private readonly PriceRule _priceRule;
        public OrderValidator(SizeRule sizeRule, PriceRule priceRule)
        {
            _sizeRule = sizeRule;
            _priceRule = priceRule;
        }
        public bool ValidateOrder(CoffeeOrder order)
        {
            if (!_sizeRule.CheckValidation(order.SizeCap))
            {
                return false;
            }
            if (!_priceRule.CheckValidation(order.Price))
            {
                return false;
            }
            return true;
        }
    }
}
