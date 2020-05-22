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
    public class ReservationController : ControllerBase
    {
        Service_Reservation service = Service_Reservation.Instance;

        [HttpPost]
        public HttpResponseMessage Put(ReservationApi reservation)
        {
            service.Create(reservation);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public IEnumerable<ReservationApi> Get()
        {
            return service.Get();
        }
        [HttpGet("{id}")]
        public ReservationApi Get(int id)
        {
            return service.Get(id);
        }
    }
}