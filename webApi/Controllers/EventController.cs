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
    public class EventController : ControllerBase
    {
        Service_Event service = Service_Event.Instance;

        //[Route("api/Event")]
        public IEnumerable<EvenementApi> Get()
        {
            return service.GetAll();
        }

        //[Route("api/Event/{id:int}")]
        [HttpGet("{id}")]
        public EvenementApi Get(int id)
       {
            return service.GetById(id);
        }

        [HttpPost]
        //[Route("api/Event")]
        public HttpResponseMessage Post(EvenementApi a)
        {
            service.Create(a);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut]
        //[Route("api/Event")]
        public HttpResponseMessage Put(EvenementApi a)
        {
            service.Update(a);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete("Delete/{id:int}")]
        // [Route("api/Event/{id:int}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }

        [HttpGet("GetDate/{id:int}")]
        public List<DateEventApi> GetDate(int id)
        {
            return service.GetDate(id);
        }

        [HttpGet("GetInfoReservation/{id:int}")]
        public List<infoReservationApi> GetInfoReservation(int id)
        {
            return service.GetInfoReservation(id);
        }

        [HttpGet("GetEventByIdSalle/{id:int}")]
        public List<EvenementApi> GetEventByIdSalle(int id)
        {
            return service.GetEventByIdSalle(id);
        }


    }
}