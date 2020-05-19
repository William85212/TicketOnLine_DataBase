using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.Infrastructure
{
    public interface ISessionTools
    {
        ClientsWeb clientsWeb { get; set; }
        bool IsAdmin { get; set; }
        bool IsAuth { get; set; }
        public string Message { get; set; }

        void Abandon();
        void AddResevation(ReservationWeb reservation);
    }
}