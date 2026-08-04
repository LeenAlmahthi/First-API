namespace Cmod_Coffee.Infrastructure
{
    public class CoffeeOrder
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string _coffeeType { set; get; } = string.Empty;
        public string SizeCap { set; get; } = string.Empty;
        public double Price { set; get; }
    }
}
