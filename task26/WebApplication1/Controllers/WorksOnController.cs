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
    public class WorksOnController(ApplicationDbContext context, IMapper mapper, IGenericRepository<WorksOnHours> WorksOnRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateWorksOnHours(WorksOnDto worksOnDto, CancellationToken cancellationToken)
        {
            var worksOn = mapper.Map<WorksOnHours>(worksOnDto);

            WorksOnRepository.Add(worksOn);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetWorksOnById), new { empId = worksOn.EmpId, ProjectId = worksOn.ProjectId }, worksOn);
        }

        [HttpGet]
        public IActionResult GetWorksOnHours(int pageNumber=1,int pageSize=10)
        {
            var worksOn = WorksOnRepository.GetAll();
            var worksOnDto = mapper.Map<List<WorksOnDto>>(worksOn).Skip(pageNumber - 1)
                .Take(pageSize).ToList();
            return Ok(worksOnDto);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetWorksOnById(int empId, int pId)
        {
            var worksOn = WorksOnRepository.GetById(empId, pId);
            if (worksOn == null)
            {
                return NotFound();
            }
            return Ok(worksOn);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteWorksOn(int empId, int pId)
        {
            var worksOn = WorksOnRepository.GetById(empId, pId);
            if (worksOn == null)
            {
                return NotFound();
            }

            WorksOnRepository.Delete(worksOn);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateWorksOn(int empId, int pId, WorksOnDto worksOnDto)
        {
            var worksOn = WorksOnRepository.GetById(empId, pId);
            if (worksOn == null)
            {
                return NotFound();
            }

            var newWorksOn = mapper.Map(worksOnDto, worksOn);
            WorksOnRepository.Update(newWorksOn);
            context.SaveChanges();

            return Ok(newWorksOn);
        }
    }
}
