using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Kinta.Models.Command;
using Microsoft.AspNetCore.Http;
using Kinta.Framework.Helper;

namespace Kinta.AppShared.Authorize
{
    public class MyServiceAuthorizeAttribute : Attribute, IResourceFilter
    {

        public MyServiceAuthorizeAttribute()
        {

        }

        private string Permission { get; set; }
        private bool IsLogged { get; set; }

        public MyServiceAuthorizeAttribute(string permission)
        {
            Permission = permission;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            try
            {
                IsLogged = context.HttpContext.User.Identity.Name.IsNotEmpty();
                if (!IsLogged)
                {
                    throw new UnauthorizedAccessException();
                }
                bool hasPermission = true;
                if (!hasPermission)
                {
                    //TODO: Add Exceoption if dont have permission 
                    throw new Exception("Access denied!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //TODO: Log here
        }



    }
}
