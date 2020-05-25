using Dal.Irepo;
using Dal.Services;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using webApi.Models;
using webApi.Utils;

namespace webApi.Services
{
    public class Service_Event : Irepo<EvenementApi>
    {
        #region singleton

        private static Service_Event _instance;
        
        public static Service_Event Instance
        {
            get
            {
                _instance = _instance ?? new Service_Event();
                return _instance;
            }
        }

        protected Service_Event()
        {

        }

        #endregion

        ServiceEvent service = ServiceEvent.Instance;
        public int Create(EvenementApi entity)
        {
            return service.Create(entity.toDal());
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public IEnumerable<EvenementApi> GetAll()
        {
            return service.GetAll().ToList().LtoA();
        }

        public EvenementApi GetById(int id)
        {
            return service.GetById(id).toApi();
        }

        public void Update(EvenementApi entity)
        {
            service.Update(entity.toDal());
        }

        public List<DateEventApi> GetDate(int id)
        {
            return service.GetInfoEvent(id).lta();
        }

        public List<EvenementApi> GetEventByIdSalle(int id)
        {
            return service.GetEventByIdSalle(id).LtoA();
        }
    }
}
