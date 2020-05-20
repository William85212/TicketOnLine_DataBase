using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Models
{
    public class ReservationWeb
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NbrPlace { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }
        public int PrixPlace { get; set; }
    }
}
