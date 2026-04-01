using Microsoft.AspNetCore.Mvc;
using Covert.Horse.Domain.Catalog;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Covert.Horse.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {


[HttpGet]
public IActionResult GetItems()
{
    var items = new List<Item>()
{
    new Item("Shirt", "Ohio State shirts.", "Nike", 29.99m),
    new Item("Shorts", "Ohio State shorts.", "Nike", 44.98m)
};
return Ok(items);
}

[HttpGet("{id:int}")]
public IActionResult GetItem(int id)
{
    var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
    item.Id = id;
    return Ok(item);
}


[HttpPost]
public IActionResult Post(Item item)
{
    return Created("/catalog/42", item);
}
[HttpPost("{id:int}/rating")]
public IActionResult PostRating(int id, [FromBody] Rating rating)
{
    var item = new Item("Shirt", "Ohio state shirt.", "Nike", 29.99m);
    item.Id = id;
    item.AddRating(rating);
    
    return Ok(item);

    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Item item)
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




