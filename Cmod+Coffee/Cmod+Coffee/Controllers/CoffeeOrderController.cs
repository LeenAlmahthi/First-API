using Cmod_Coffee.Application.Customer;
using Cmod_Coffee.Application.custtomer;
using Cmod_Coffee.DTOs;
using Cmod_Coffee.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Cmod___Coffee.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CoffeeOrderController : ControllerBase
    {
        private readonly PostCoffee PostOrder;
        private readonly DeleteOrder DeleteOrder;
        private readonly GetOrder GetOrder;
        public CoffeeOrderController(GetOrder data, PostCoffee Post, DeleteOrder _Delete)
        {
            GetOrder = data;
            PostOrder = Post;
            DeleteOrder = _Delete;
        }
        [HttpGet]
        public IActionResult GetCoffee()
        {
            var re = GetOrder.GetAll();
            if (re == null)
                   return NotFound("No coffee found.");
            return Ok(re);
        }
        [HttpGet("{id}")]
        public IActionResult GetCoffeeById(int id)
        {
            var re = GetOrder.GetById(id);
            if (re == null)
                return NotFound("No coffee found with the given ID.");
            return Ok(re);
        }
        [HttpPost]
        public IActionResult MakeCoffee(CreateOrderRequest info)
        {
            if (info == null)
                return BadRequest("Invalid coffee order data.");
            var coffee = PostOrder.Post(info);
            if (coffee == null)
                return BadRequest("Invalid coffee order data.");
            return Ok (info);
        }
        [HttpDelete]
        public IActionResult deleteorder(int id)
        {
            string re = DeleteOrder._DeleteOrder(id);
            if (re.IsNullOrEmpty())
                return NotFound("No coffee order found with the given ID.");
            return Ok("Coffee order deleted successfully.");
        }
    }
}
