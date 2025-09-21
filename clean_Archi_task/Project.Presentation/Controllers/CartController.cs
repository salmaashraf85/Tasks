using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CartItems.Commands.Add;
using Project.Application.Features.Carts.Commands.Add;
using Project.Application.Features.Carts.Commands.Delete;
using Project.Application.Features.Carts.Queries.GetCartById;
using Project.Domain.Routes.BaseRouter;

namespace Project.Presentation.Controllers
{
    public class CartController : BaseController
    {
        [HttpPost(Router.CartRouter.Add)]
        public async Task<IActionResult> Create(AddCartCommand command)
        {
            var result = await mediator.Send(command);
            return Result(result);
        }

        [HttpDelete(Router.CartRouter.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await mediator.Send(new DeleteCartCommand(id));
            return Result(result);
        }

        [HttpGet(Router.CartRouter.GetById)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetCartQuery(id));
            return Result(result);
        }
    }


}
