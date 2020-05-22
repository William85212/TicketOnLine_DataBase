using Dal.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Utils;

namespace webApi.Services
{
    public class Service_Reservation
    {
        private static Service_Reservation _instance;

        public static Service_Reservation Instance
        {
            get
            {
                _instance = _instance ?? new Service_Reservation();
                return _instance;
            }
        }

        private Service_Reservation()
        {

        }
        ServiceReservation service = ServiceReservation.Instance;  


        public int Create(ReservationApi api)
        {
            return service.Create(api.ToD());
        }

        public IEnumerable<ReservationApi> Get()
        {
            return service.Get().lta();
        }
        public ReservationApi Get(int id )
        {
            return service.Get(id).toApi();
        }
    }
}
