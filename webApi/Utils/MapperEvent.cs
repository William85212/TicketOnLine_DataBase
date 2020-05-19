using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;


namespace webApi.Utils
{
    public static class MapperEvent
    {
        public static Evenement toDal(this EvenementApi api)
        {
            Evenement e = new Evenement
            {
                NomSpectacle = api.NomSpectacle,
                Realisateur = api.Realisateur,
                Description = api.Description,
                Duree =new TimeSpan( api.Duree),
                Capacite = api.Capacite,
                PlaceRestante = api.PlaceRestante,
                IdSalle = api.IdSalle
            };
            return e;
        }

        public static EvenementApi toApi(this Evenement e)
        {
            EvenementApi a = new EvenementApi
            {
                NomSpectacle = e.NomSpectacle,
                Realisateur = e.Realisateur,
                Description = e.Description,
                Duree = e.Duree.Ticks,
                Capacite = e.Capacite,
                PlaceRestante = e.PlaceRestante,
                IdSalle = e.IdSalle
            };
            return a; 
        }

        public static List<Evenement> LtoD(this List<EvenementApi> a)
        {
            List<Evenement> l = new List<Evenement>();
            foreach (EvenementApi item in a)
            {
                l.Add(item.toDal());
            }
            return l;
        }

        public static List<EvenementApi> LtoA(this List<Evenement> e)
        {
            List<EvenementApi> a = new List<EvenementApi>();
            foreach (Evenement item in e)
            {
                a.Add(item.toApi());
            }
            return a;
        }

    }
}
