using Microsoft.AspNetCore.Mvc;
using exercise1.Models;

namespace exercise1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        public ItemsController()
        {
            Console.WriteLine("\nItemsController loaded\n");
        }

        private static List<Item> items = new()
        {
            new Item { Id = 1, Name = "Pen" },
            new Item { Id = 2, Name = "Book" }
        };

        [HttpGet]
        public IActionResult Get() => Ok(items);

        [HttpPost]
        public IActionResult Post(Item item)
        {
            item.Id = items.Count + 1;
            items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
    }
}