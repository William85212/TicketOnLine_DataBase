using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Utils
{
    public static class MapperClients
    {
        public static ClientsApi ToApi(this Clients c)
        {
            ClientsApi api = new ClientsApi
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                DateNaisance = c.DateNaisance,
                Sexe = c.Sexe,
                Adresse = c.Adresse,
                Email = c.Email,
                IsActive = c.IsActive,
                IsAdmin = c.IsAdmin,
                Password = c.Password
            };
            return api;
        }

        public static Clients ToDal(this ClientsApi api)
        {
            Clients c = new Clients
            {
                Id = api.Id,
                Nom = api.Nom,
                Prenom = api.Prenom,
                DateNaisance = api.DateNaisance,
                Sexe = api.Sexe,
                Adresse = api.Adresse,
                Email = api.Email,
                IsActive = api.IsActive,
                IsAdmin = api.IsAdmin,
                Password = api.Password
            };
            return c;
        }

        public static List<ClientsApi> lToApi(this List<Clients> lc)
        {
            List<ClientsApi> apiL = new List<ClientsApi>();
            foreach (Clients item in lc)
            {
                apiL.Add(item.ToApi());
            }
            return apiL;
        }

        public static List<Clients> LToD(this List<ClientsApi> ap)
        {
            List<Clients> cl = new List<Clients>();
            foreach (ClientsApi item in ap)
            {
                cl.Add(item.ToDal());
            }
            return cl;
        }
            

    }
}
