using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.Infrastructure
{
    public class SessionTools : ISessionTools
    //ISessionTools
    {

        //
        private ISession Session { get; }

        public SessionTools(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }
        //
        public string Message
        {
            get { return Session.GetString(nameof(Message)); }
            set { Session.SetString(nameof(Message), value); }
        }
        public bool IsAuth
        {
            get
            {
                return JsonConvert.DeserializeObject<bool>(Session.GetString(nameof(IsAuth)));
            }
            set
            {
                Session.SetString(nameof(IsAuth), JsonConvert.SerializeObject(value));
            }
        }


        public bool IsAdmin
        {
            get
            {
                return JsonConvert.DeserializeObject<bool>(Session.GetString(nameof(IsAdmin)));
            }
            set
            {
                Session.SetString(nameof(IsAdmin), JsonConvert.SerializeObject(value));
            }
        }

        public ClientsWeb clientsWeb
        {
            get
            {
                return (Session.Keys.Contains(nameof(clientsWeb))) ? JsonConvert.DeserializeObject<ClientsWeb>(Session.GetString(nameof(clientsWeb))) : null;
            }
            set
            {
                Session.SetString(nameof(clientsWeb), JsonConvert.SerializeObject(value));
            }
        }

        public EventWeb eventWeb
        {
            get
            {
                return Session.Keys.Contains(nameof(eventWeb)) ? JsonConvert.DeserializeObject<EventWeb>(Session.GetString(nameof(eventWeb))) : null;
            }
            set
            {
                Session.SetString(nameof(eventWeb), JsonConvert.SerializeObject(value));
            }
        }

        public DateTime? DateEvent
        {
            get
            {
                return Session.Keys.Contains(nameof(DateEvent)) ? JsonConvert.DeserializeObject<DateTime?>(Session.GetString(nameof(DateEvent))) : null;
            }
            set
            {
                Session.SetString(nameof(DateEvent), JsonConvert.SerializeObject(value));
            }
        }

        //pour Stocker la liste des Billets Reserver

        //public List<ReservationWeb> Reservation
        //{
        //    get
        //    {

        //    }
        //    private set
        //    {

        //    }
        //}

        public void AddResevation(ReservationWeb reservation)
        {

        }

        public void Abandon()
        {
            Session.Clear();
        }

        


    }

}
