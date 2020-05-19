using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketOnLine_webSite.Infrastructure;
using TicketOnLine_webSite.Utils.Custom_attribute;

namespace TicketOnLine_webSite.Controllers
{
    [IsLoggedAction]
    public class BaseController : Controller
    {
        protected internal ISessionTools Sessiontools { get; set; }
        public BaseController(ISessionTools sess)
        {
            Sessiontools = sess;
        }
      
    }
}