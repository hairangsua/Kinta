using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Kinta.Models.Command;
using Kinta.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
namespace Kinta.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var task = base.OnActionExecutionAsync(context, next);

            return task;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}