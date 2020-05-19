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
    public class Service_Client : Irepo<ClientsApi>
    {
        #region singleton 
        private static Service_Client _instance;

        public static Service_Client Instance
        {
            get
            {
                _instance = _instance ?? new Service_Client();
                return _instance;
            }
        }

        //protected Service_Client()
        //{
                
        //}

        #endregion

        ServiceClient service = ServiceClient.Istance;


        public int Create(ClientsApi c)
        {
            return service.Create(c.ToDal());
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public IEnumerable<ClientsApi> GetAll()
        {
            return service.GetAll().ToList().lToApi();
        }

        public ClientsApi GetById(int id)
        {
            return service.GetById(id).ToApi();
        }

        public void Update(ClientsApi entity)
        {
            service.Update(entity.ToDal());
        }
    }
}
