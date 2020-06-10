using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.Infrastructure
{
    public class SessionTools :ISessionTools
    //ISessionTools
    {

        //injectione del dependencia
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

        public List<ReservationWeb> Reservation   //Panier
        {
            get
            {
                if (Session.GetString(nameof(Reservation)) is null)
                    Reservation = new List<ReservationWeb>();
                return JsonConvert.DeserializeObject<List<ReservationWeb>>(Session.GetString(nameof(Reservation)));
            }
            private set
            {
                Session.SetString(nameof(Reservation), JsonConvert.SerializeObject(value));
            }
        }

        public void AddReservation(ReservationWeb reservation)
        {
            List<ReservationWeb> resL = Reservation;
            resL.Add(reservation);
            reservation.Id = resL.Count;
            Reservation = resL;
        }
        public void RemoveOneReservation(int id)
        {
            List<ReservationWeb> l = Reservation;
            int i = 0;
            while (l[i].Id != id)
            {
                i++;

            }
            if (l[i].Id == id)
            {
                l[i].NbrPlace--;
            }
            Reservation = l;
        }
        public void AddOneReservation(int id)
        {
            List<ReservationWeb> l = Reservation;
            int i = 0;
            while( l[i].Id != id)
            {
                i++;
                
            }
            if (l[i].Id == id)
            {
                l[i].NbrPlace++;
            }
            Reservation = l;
        }
        public void RemoveAllReservation()
        {
            Reservation = new List<ReservationWeb>();
        }

        public void Abandon()
        {
            Session.Clear();
        }

        


    }

}
