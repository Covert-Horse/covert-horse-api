using Microsoft.AspNetCore.Mvc;
using Covert.Horse.Domain.Catalog;
using Covert.Horse.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Covert.Horse.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _context;

        public CatalogController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_context.Items.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return Created($"/catalog/{item.Id}", item);
        }

        [HttpPost("{id:int}/rating")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = _context.Items
                .Include(i => i.Ratings)
                .FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            item.AddRating(rating);
            _context.SaveChanges();

            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item updatedItem)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            item.Brand = updatedItem.Brand;
            item.Price = updatedItem.Price;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}