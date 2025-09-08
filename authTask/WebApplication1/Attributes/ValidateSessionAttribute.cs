using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using System.Text;

namespace WebApplication1.Attributes
{
    public class ValidateSessionAttribute(ApplicationDbContext _dbContext) : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("encodedSessionId", out var sessionIdObj) || sessionIdObj == null)
            {
                context.Result = new BadRequestObjectResult("SessionId is required");
                return;
            }

                string encodedSessionId = sessionIdObj.ToString()!;
                var sessionBytes = Convert.FromBase64String(encodedSessionId);
                var sessionId = Encoding.UTF8.GetString(sessionBytes);

                context.HttpContext.Items["DecodedSessionId"] = sessionId;
           
        }
    }
}