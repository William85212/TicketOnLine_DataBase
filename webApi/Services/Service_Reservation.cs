using Dal.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Services
{
    public class Service_Reservation
    {
        private static Service_Reservation _instance;

        public Service_Reservation Instance
        {
            get
            {
                _instance = _instance ?? new Service_Reservation();
                return _instance;
            }
        }

        ServiceReservation service = ServiceReservation.Instance;  


        public int Create(ReservationApi api)
        {
            return service.Create(api)
        }
    }
}
