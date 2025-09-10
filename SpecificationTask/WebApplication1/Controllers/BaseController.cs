﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication1.Global;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IActionResult Result(Response response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                case HttpStatusCode.UnsupportedMediaType:
                    var BadRequestObjectResult = new BadRequestObjectResult(response);
                    BadRequestObjectResult.StatusCode = (int)HttpStatusCode.UnsupportedMediaType;
                    return BadRequestObjectResult;
                default:
                    return new BadRequestObjectResult(response);
            }
        }
    }
}

   