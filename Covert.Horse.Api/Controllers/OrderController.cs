using Microsoft.AspNetCore.Mvc;
using Covert.Horse.Domain.Order;

namespace Covert.Horse.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = new List<Order>()
            {
                new Order("Isaiah", new List<string> { "Shirt", "Shorts" }, 74.97m),
                new Order("John", new List<string> { "Hat" }, 19.99m)
            };

            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrder(int id)
        {
            var order = new Order("Isaiah", new List<string> { "Shirt" }, 29.99m);
            order.Id = id;

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            return Created("/order/42", order);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Order order)
        {
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}