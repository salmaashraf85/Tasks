using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(Data.ApplicationDbContext context, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleDto roleDto, CancellationToken cancellationToken)
        {
            var role = mapper.Map<Role>(roleDto);
            await context.Roles.AddAsync(role, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var employees = context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = context.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateRole(int id, RoleDto roleDto)
        {
            var role = context.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            var newRole = mapper.Map(roleDto, role);
            context.Roles.Update(newRole);
            context.SaveChanges();

            return Ok(role);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var role = context.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            context.Roles.Remove(role);
            context.SaveChanges();
            return NoContent();
        }
    }
}
