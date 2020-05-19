using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Models
{
    public class SalleWeb
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Lieux { get; set; }
        public int Capacite { get; set; }
        public string Image { get; set; }
    }
}
