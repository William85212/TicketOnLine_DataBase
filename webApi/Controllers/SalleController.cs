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
    public class SalleController : ControllerBase
    {
        Service_Salle service = Service_Salle.Instance;
        [HttpPost]
        public HttpResponseMessage Put(SalleApi entity)
        {
            service.Create(entity);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }
  
        public IEnumerable<SalleApi> Get()
        
        {
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public SalleApi Get(int id)
        {
            return service.GetById(id);
        }
        [HttpPut]
        public HttpResponseMessage Update(SalleApi entity)
        {
            service.Update(entity);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}