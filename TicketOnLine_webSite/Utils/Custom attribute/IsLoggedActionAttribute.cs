using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Controllers;

namespace TicketOnLine_webSite.Utils.Custom_attribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited =true)]
    public class IsLoggedActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            BaseController controller = (BaseController)context.Controller;
            controller.ViewBag.IsLogged = !(controller.Sessiontools.clientsWeb is null);

        }
    }
}
