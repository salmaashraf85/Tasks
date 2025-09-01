using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using AutoMapper;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Depratment> DepartmentRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentDto departmentDto, CancellationToken cancellationToken)
        {
            var dept = mapper.Map<Depratment>(departmentDto);

     
            DepartmentRepository.Add(dept);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetDepartmentById), new { dept.Dno }, dept);
        }

        [HttpGet]
        public IActionResult GetDepartment(int pageNumber = 1, int pageSize = 10)
        {
           var depratments = DepartmentRepository.GetAll();
           var departments =mapper.Map<List<DepartmentDto>>(depratments).Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
            return Ok(departments);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetDepartmentById(int id)
        {
            var dept = DepartmentRepository.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }
            var deptDto=mapper.Map<DepartmentDto>(dept);
            return Ok(deptDto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var dept = DepartmentRepository.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }

            DepartmentRepository.Delete(dept);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateDepartment(int id, DepartmentDto updatedDepartemt)
        {
            var dept = DepartmentRepository.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }

            var newDept = mapper.Map(updatedDepartemt, dept);
            DepartmentRepository.Update(newDept);
            context.SaveChanges();
            var deptDto = mapper.Map<DepartmentDto>(newDept);
            return Ok(deptDto);
        }
    }
}

