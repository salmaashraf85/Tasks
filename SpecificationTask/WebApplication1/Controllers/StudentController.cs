using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppMetaData;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Features.Student.Query.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        [HttpGet(Router.StudentRouter.MainId)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetStudentsWithCourses(id));
            return Ok(result);
        }

        [HttpPost(Router.StudentRouter.Main)]
        public async Task<IActionResult> Add([FromBody] AddStudent command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Router.StudentRouter.Main)]
        public async Task<IActionResult> Update([FromBody] UpdateStudent command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete(Router.StudentRouter.MainId)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteStudent(id));
            return Ok(result);
        }
    }
}
