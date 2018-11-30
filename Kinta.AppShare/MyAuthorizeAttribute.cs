using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Kinta.Models.Command;
using Microsoft.AspNetCore.Http;

namespace Kinta.AppShared.Authorize
{
    public class MyServiceAuthorizeAttribute : Attribute, IResourceFilter
    {

        private IUserService _userService;
        public MyServiceAuthorizeAttribute()
        {

        }

        public MyServiceAuthorizeAttribute(IUserService userService)
        {
            _userService = userService;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var b = context.HttpContext;

            _userService = context.HttpContext.RequestServices.GetService<IUserService>();

            //var userId = int.Parse(context.Principal.Identity.Name);
            //var user = userService.GetById(userId);
            //if (user == null)
            //{
            //    // return unauthorized if user no longer exists
            //    context.Fail("Unauthorized");
            //}
            //return Task.CompletedTask;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
