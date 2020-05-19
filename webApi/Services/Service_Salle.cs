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
    public class Service_Salle : Irepo<SalleApi>
    {
        #region Singleton
        private static Service_Salle _instance;
        public static Service_Salle Instance
        {
            get
            {
                _instance = _instance ?? new Service_Salle();
                return _instance;
            }
        }
        protected Service_Salle()
        {
                
        }

        #endregion

        ServiceSalle service = ServiceSalle.Instance;

        public int Create(SalleApi entity)
        {
            return service.Create(entity.toDal());
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public IEnumerable<SalleApi> GetAll()
        {
            return service.GetAll().ltoa();
        }

        public SalleApi GetById(int id)
        {
            return service.GetById(id).ToApi();
        }

        public void Update(SalleApi entity)
        {
            service.Update(entity.toDal());
        }
    }
}
