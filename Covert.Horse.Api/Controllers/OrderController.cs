using Microsoft.AspNetCore.Mvc;
using Covert.Horse.Api.Data;
using Covert.Horse.Domain.Order;

namespace Covert.Horse.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly StoreContext _context;

    public OrderController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(_context.Orders.ToList());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOrder(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]
    public IActionResult Post(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();

        return Created($"/order/{order.Id}", order);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Order updatedOrder)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        order.CustomerName = updatedOrder.CustomerName;
        order.Items = updatedOrder.Items;
        order.TotalAmount = updatedOrder.TotalAmount;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        _context.Orders.Remove(order);
        _context.SaveChanges();

        return NoContent();
    }
}