using Dal.Irepo;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Utils;

namespace webApi.Services
{
    public class Service_Commentaire : Irepo<CommentaireApi>
    {
        #region singleton 
        private static Service_Commentaire _Instance;

        public static Service_Commentaire Instance
        {
            get
            {
                _Instance = _Instance ?? new Service_Commentaire();
                return _Instance;
            }
        }
        protected Service_Commentaire()
        {

        }

        #endregion

        ServiceCommentaire service = ServiceCommentaire.Istance;

        public CommentaireApi GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentaireApi> GetAll()
        {
            return service.GetAll().ToList().la();
        }

        public int Create(CommentaireApi entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CommentaireApi entity)
        {
            throw new NotImplementedException();
        }
    }
}
