using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppMetaData;
using WebApplication1.Features.Course.Query.Models;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Features.Student.Command.Models;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        [HttpGet(Router.CourseRoute.MainId)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetCourseWithStudents(id));
            return Ok(result);
        }

        [HttpPost(Router.CourseRoute.Main)]
        public async Task<IActionResult> Add([FromBody] CourseAddDto command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Router.CourseRoute.Main)]
        public async Task<IActionResult> Update([FromBody] UpdateCourse command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete(Router.CourseRoute.MainId)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteCourse(id));
            return Ok(result);
        }
    }
}
