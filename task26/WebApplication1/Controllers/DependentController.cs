using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Dependent> DependentRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDependent(dependentDto dependDto, CancellationToken cancellationToken)
        {
            var dependent = mapper.Map<Dependent>(dependDto);
            DependentRepository.Add(dependent);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetDependentById), new { empId = dependent.EmpId, dname = dependent.Dname }, dependent);
        }

        [HttpGet]
        public IActionResult GetDependents(int pageNumber=1,int pageSize=10)
        {
            var dependents = DependentRepository.GetAll();
            var dependentsDto = mapper.Map< List <dependentDto>>(dependents).Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
            return Ok(dependentsDto);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetDependentById(int empId, string dname)
        {
            var dependent = DependentRepository.GetById(empId, dname);
            if (dependent == null)
            {
                return NotFound();
            }
            return Ok(dependent);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDependent(int id,string dname)
        {
            var dependent = DependentRepository.GetById(id,dname);
            if (dependent == null)
            {
                return NotFound();
            }

            DependentRepository.Delete(dependent);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateDependent(int id, string dname,dependentDto dependDto)
        {
            var dependent = DependentRepository.GetById(id,dname);
            if (dependent == null)
            {
                return NotFound();
            }

            var newDependent = mapper.Map(dependDto, dependent);
            DependentRepository.Update(newDependent);
            context.SaveChanges();

            return Ok(newDependent);
        }
    }
}
