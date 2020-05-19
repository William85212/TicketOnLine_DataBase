using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Infrastructure;

namespace TicketOnLine_webSite.Utils.Custom_attribute
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AccesAttribute : TypeFilterAttribute
    {
        public AccesAttribute() : base(typeof(AuthRequiredFilter))
        {
        }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ISessionTools sessionTools = (ISessionTools)context.HttpContext.RequestServices.GetService(typeof(ISessionTools));

            if(sessionTools.clientsWeb is null)
            {
                context.Result = new RedirectToRouteResult(new { action = "", controller = "" });
            }
        }
    }
}
