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
        public static ReservationApi toApi(this Reservation r)
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

        public static Reservation ToD(this ReservationApi api)
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

        public static List<ReservationApi> lta(this List<Reservation> r)
        {
            List<ReservationApi> a = new List<ReservationApi>();

            foreach (Reservation item in r)
            {
                a.Add(item.toApi());
            }
            return a;
        }

        public static List<Reservation> ltd(List<ReservationApi> a)
        {
            List<Reservation> d = new List<Reservation>();

            foreach (ReservationApi item in a)
            {
                d.Add(item.ToD());
            }
            return d;
        }

    }
}
