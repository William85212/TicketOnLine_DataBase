using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Utils
{
    public static class MapperCommentaire
    {
        public static CommentaireApi toApi(this Commentaire c)
        {
            CommentaireApi a = new CommentaireApi
            {
                Id = c.Id,
                Commentaires = c.Commentaires,
                IdClient = c.IdClient,
                IdEvent = c.IdEvent
            };
            return a;
        }

        public static Commentaire toD(this CommentaireApi a)
        {
            Commentaire c = new Commentaire
            {
                Id = a.Id,
                Commentaires = a.Commentaires,
                IdClient = a.IdClient,
                IdEvent = a.IdEvent,
            };
            return c;
        }

        public static List<CommentaireApi> la(this List<Commentaire> c)
        {
            List<CommentaireApi> a = new List<CommentaireApi>();

            foreach (Commentaire item in c)
            {
                a.Add(item.toApi());
            }
            return a;
        }

        public static List<Commentaire> ld(this List<CommentaireApi> a)
        {
            List<Commentaire> c = new List<Commentaire>();

            foreach (CommentaireApi item in a)
            {
                c.Add(item.toD());
            }
            return c;
        }
    }
}
