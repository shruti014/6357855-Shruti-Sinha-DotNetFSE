using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using exercise3.Models;
using exercise3.Filters;

namespace exercise3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 60000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "SQL" } },
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            };
        }

        [HttpGet("standard")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetStandard()
        {
            // throw new Exception("Test exception for filter");
            return Ok(_employees);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Employee> Create([FromBody] Employee emp)
        {
            emp.Id = _employees.Count + 1;
            _employees.Add(emp);
            return CreatedAtAction(nameof(GetStandard), new { id = emp.Id }, emp);
        }
    }
}