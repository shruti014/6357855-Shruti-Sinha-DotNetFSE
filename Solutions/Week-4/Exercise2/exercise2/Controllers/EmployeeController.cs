using Microsoft.AspNetCore.Mvc;

namespace exercise2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<string> employees = new()
        {
            "Alice", "Bob", "Charlie"
        };

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] string name)
        {
            employees.Add(name);
            return Created("", name);
        }
    }
}