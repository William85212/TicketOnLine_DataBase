using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Utils
{
    public static class MapperReservation
    {
        public static ReservationApi toApi(Reservation r)
        {
            ReservationApi api = new ReservationApi
            {
                Date = r.Date,
                NbrPlace = r.NbrPlace,
                IdClient = r.IdClient,
                IdEvent = r.IdEvent,
                PrixPlace = r.PrixPlace
            };
            return api;
        }

        public static Reservation ToD(ReservationApi api)
        {
            Reservation r = new Reservation
            {
                Date = api.Date,
                NbrPlace = api.NbrPlace,
                IdClient = api.IdClient,
                IdEvent = api.IdEvent,
                PrixPlace = api.PrixPlace
            };
            return r;
        }


    }
}
