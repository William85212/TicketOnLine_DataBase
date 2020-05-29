using System.Collections.Generic;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.Infrastructure
{
    public interface ISessionTools
    {
        ClientsWeb clientsWeb { get; set; }
        EventWeb eventWeb { get; set; }
        bool IsAdmin { get; set; }
        bool IsAuth { get; set; }
        public string Message { get; set; }
        List<ReservationWeb> Reservation { get; }
        void Abandon();
        void AddReservation(ReservationWeb web);
        void RemoveOneReservation(int id);
        void AddOneReservation(int id);
        void RemoveAllReservation();
    }
}