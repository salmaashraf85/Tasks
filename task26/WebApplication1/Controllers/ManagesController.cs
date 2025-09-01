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
    public class ManagesController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Manages> ManagesRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateManages(ManageDto manageDto, CancellationToken cancellationToken)
        {
            var manage = mapper.Map<Manages>(manageDto);
            ManagesRepository.Add(manage);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetManageById), new {manage.Id}, manage);
        }

        [HttpGet]
        public IActionResult GetManages(int pageNumber=1,int pageSize=10)
        {
            var manages = ManagesRepository.GetAll();
            var managesDto=mapper.Map<List<ManageDto>>(manages).Skip(pageNumber-1)
                .Take(pageSize).ToList();
            return Ok(managesDto);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetManageById(int Id)
        {
            var manage = ManagesRepository.GetById(Id);
            if (manage == null)
            {
                return NotFound();
            }
            return Ok(manage);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteManage(int Id)
        {
            var manage = ManagesRepository.GetById(Id);
            if (manage == null)
            {
                return NotFound();
            }

            ManagesRepository.Delete(manage);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateManage(int Id, Manages updatedManage)
        {
            var manage = ManagesRepository.GetById(Id);
            if (manage == null)
            {
                return NotFound();
            }

            var newManage = mapper.Map(updatedManage, manage);
            ManagesRepository.Update(newManage);
            context.SaveChanges();

            return Ok(newManage);
        }
    }
}
