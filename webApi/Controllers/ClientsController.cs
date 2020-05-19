using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Dal.Irepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Services;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        Service_Client service = Service_Client.Instance;


        public IEnumerable<ClientsApi> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ClientsApi Get(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
     
        public HttpResponseMessage Post(ClientsApi clients)
        {
            service.Create(clients);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut]

        public HttpResponseMessage Put(ClientsApi api)
        {
            service.Update(api);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
    
        public void Delete(int id)
        {
            service.Delete(id);
        }

    }
}