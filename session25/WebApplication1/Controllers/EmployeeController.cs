using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(Data.ApplicationDbContext context, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddEmplyee([FromBody] EmpDto employeeDto, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            await context.Employees.AddAsync(employee, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id, EmpDto updatedEmployee)
        {
            var emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound();
            }

            var newEmp = mapper.Map(updatedEmployee, emp);
            context.Employees.Update(newEmp);
            context.SaveChanges();

            return Ok(emp);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound();
            }

            context.Employees.Remove(emp);
            context.SaveChanges();
            return NoContent();
        }
    }
}
