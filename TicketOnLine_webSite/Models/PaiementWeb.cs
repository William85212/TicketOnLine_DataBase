using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Models
{
    public class PaiementWeb
    {
        public int Id { get; set; }
        public bool Paier { get; set; }
        public int IdPaiement { get; set; }
        public bool EnvoieFactutre { get; set; }
    }
}
