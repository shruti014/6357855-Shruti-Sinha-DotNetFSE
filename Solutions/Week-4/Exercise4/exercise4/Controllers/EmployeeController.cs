using Microsoft.AspNetCore.Mvc;
using exercise4.Dtos;
using exercise4.Services;

namespace exercise4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDto>> GetAll() => _service.GetAll();

        [HttpPut]
        public ActionResult<EmployeeDto> Update([FromBody] EmployeeDto emp)
        {
            if (emp.Id <= 0)
                return BadRequest("Invalid employee id");

            var existing = _service.GetById(emp.Id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            var updated = _service.Update(emp);
            return Ok(updated);
        }
    }
}