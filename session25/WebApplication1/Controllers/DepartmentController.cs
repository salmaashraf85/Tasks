using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(Data.ApplicationDbContext context, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DeptDto departmentDto, CancellationToken cancellationToken)
        {
            var department = mapper.Map<Department>(departmentDto);
            await context.Departments.AddAsync(department, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpGet]
        public IActionResult GetDepartemets()
        {
            var dept = context.Departments.ToList();
            return Ok(dept);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var dept = context.Departments.FirstOrDefault(d => d.Id == id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateDepartment(int id, DeptDto deptDto)
        {
            var dept = context.Employees.FirstOrDefault(d => d.Id == id);
            if (dept == null)
            {
                return NotFound();
            }

            var newDept = mapper.Map(deptDto, dept);
            context.Employees.Update(newDept);
            context.SaveChanges();

            return Ok(dept);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartemt(int id)
        {
            var dept = context.Departments.FirstOrDefault(d => d.Id == id);
            if (dept == null)
            {
                return NotFound();
            }

            context.Departments.Remove(dept);
            context.SaveChanges();
            return NoContent();
        }
    }
}
