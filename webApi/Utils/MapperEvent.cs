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
                Id = api.Id,
                NomSpectacle = api.NomSpectacle,
                Realisateur = api.Realisateur,
                Description = api.Description,
                Duree =new TimeSpan( api.Duree),
                PlaceRestante = api.PlaceRestante,
                Image = api.Image,
                Prix = api.Prix
            };
            return e;
        }

        public static EvenementApi toApi(this Evenement e)
        {
            EvenementApi a = new EvenementApi
            {
                Id = e.Id,
                NomSpectacle = e.NomSpectacle,
                Realisateur = e.Realisateur,
                Description = e.Description,
                Duree = e.Duree.Ticks,
                PlaceRestante = e.PlaceRestante,
                Image= e.Image, 
                Prix = e.Prix
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


        public static DateEventApi toApi(this DateEvent de)
        {
            DateEventApi dea = new DateEventApi
            {
                DateRepresentation = de.DateRepresentation
            };
            return dea;
        }
        public static DateEvent tod(this DateEventApi de)
        {
            DateEvent dea = new DateEvent
            {
                DateRepresentation = de.DateRepresentation
            };
            return dea;
        }

        public static List<DateEventApi> lta(this List<DateEvent> de)
        {
            List<DateEventApi> dea = new List<DateEventApi>();

            foreach (DateEvent item in de)
            {
                dea.Add(item.toApi());
            }
            return dea;
        }
        public static List<DateEvent> ltd(this List<DateEventApi> de)
        {
            List<DateEvent> dea = new List<DateEvent>();

            foreach (DateEventApi item in de)
            {
                dea.Add(item.tod());
            }
            return dea;
        }

    }
}
