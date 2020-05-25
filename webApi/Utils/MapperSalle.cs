using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Utils
{
    public static class MapperSalle
    {
        public static SalleApi ToApi(this Salles s)
        {
            SalleApi api = new SalleApi
            {
                Id = s.Id,
                Nom = s.Nom,
                Lieux = s.Lieux,
                Capacite = s.Capacite,
                Image = s.Image
            };
            return api;
        }


        public static Salles toDal(this SalleApi api)
        {
            Salles s = new Salles
            {
                Id = api.Id,
                Nom = api.Nom,
                Lieux = api.Lieux,
                Capacite = api.Capacite,
                Image = api.Image
            };
            return s;
        }

        public static IEnumerable<Salles> ltoD(this List<SalleApi> api)
        {
            List<Salles> sl = new List<Salles>();

            foreach (SalleApi item in api)
            {
                sl.Add(item.toDal());
            }
            return sl;
        }

        public static IEnumerable<SalleApi> ltoa(this IEnumerable<Salles> s)
        {
            List<SalleApi> api = new List<SalleApi>();
            foreach(Salles item in s)
            {
                api.Add(item.ToApi());
            }
            return api;
        }
    }
}
