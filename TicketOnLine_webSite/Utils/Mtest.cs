using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.Utils
{
    public static class Mtest
    {
        public static ReservationWeb toto(this DateTime d)
        {
            ReservationWeb w = new ReservationWeb
            {
                Date = d
            };
            return w;
        }
    }
}
