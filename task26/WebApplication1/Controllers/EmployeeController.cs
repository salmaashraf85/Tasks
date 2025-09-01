using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Employee> EmployeeRepository, IFileUpload _fileUpload) : ControllerBase
    {
       // private readonly ;
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeDto employeeDto, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            if (employee.ImagePath != null)
            {
                employee.ImagePath = await _fileUpload.UploadAsync(employeeDto.Image, "employee", cancellationToken);
            }
            EmployeeRepository.Add(employee);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }


        [HttpGet]
        public IActionResult GetEmployess(int pageNumber = 1, int pageSize = 10)
        {
            var employees = EmployeeRepository.GetAll();       
            var employeeDtos = mapper.Map<List<EmployeeDto>>(employees).Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
            return Ok(employeeDtos);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = EmployeeRepository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }
            var employeeDtos = mapper.Map<EmployeeDto>(emp);
            return Ok(employeeDtos);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = EmployeeRepository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }

            EmployeeRepository.Delete(emp);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id, EmployeeDto updatedEmployee)
        {
            var emp = EmployeeRepository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }

            var newEmp = mapper.Map(updatedEmployee, emp);
            EmployeeRepository.Update(newEmp);
            context.SaveChanges();

            var employeeDtos = mapper.Map<EmployeeDto>(newEmp);
            return Ok(employeeDtos);
        }
    }
}
