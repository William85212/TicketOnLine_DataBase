using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Services;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        Service_Commentaire service = Service_Commentaire.Instance;

        public IEnumerable<CommentaireApi> Get()
        {
            return service.GetAll();
        }
        [HttpPost]
        public HttpResponseMessage Post(CommentaireApi comApi)
        {
            service.Create(comApi);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}