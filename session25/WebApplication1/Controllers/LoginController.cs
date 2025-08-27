using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(Data.ApplicationDbContext context, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddLogin([FromBody] loginDto loginDto, CancellationToken cancellationToken)
        {
            var login = mapper.Map<Login>(loginDto);
            await context.Logins.AddAsync(login, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetLoginById), new { id = login.Id }, login);
        }

        [HttpGet]
        public IActionResult GetLogins()
        {
            var login = context.Logins.ToList();
            return Ok(login);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoginById(int id)
        {
            var login = context.Logins.FirstOrDefault(l => l.Id == id);
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateLogin(int id, loginDto updatedLogin)
        {
            var login = context.Logins.FirstOrDefault(l => l.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            var newLog = mapper.Map(updatedLogin, login);
            context.Logins.Update(newLog);
            context.SaveChanges();

            return Ok(login);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteLogin(int id)
        {
            var log = context.Logins.FirstOrDefault(l => l.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            context.Logins.Remove(log);
            context.SaveChanges();
            return NoContent();
        }
    }
}
