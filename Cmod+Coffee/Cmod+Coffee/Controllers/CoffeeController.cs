using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmoCoffee.Data;
namespace Cmod___Coffee.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly DataContext _Data;
        public CoffeeController(DataContext data)
        {
            _Data = data;
        }
        [HttpGet]
        public IActionResult GetCoffee()
        {
            var re = _Data.Data.ToList();
            if (re == null)
                   return NotFound("No coffee found.");
            return Ok(re);
        }
        [HttpPost]
        public IActionResult MakeCoffee(CoffeeAttribet info_)
        {
            var coffee = new CoffeeAttribet();
            coffee.Name = info_.Name;
            coffee._coffeeType = info_._coffeeType;
            coffee.SizeCap = info_.SizeCap;
            coffee.Price = info_.Price;
            _Data.Data.Add(coffee);
            _Data.SaveChanges();
            return Ok (info_);

        }
    }
}
