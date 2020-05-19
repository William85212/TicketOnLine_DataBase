using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.ViewModel
{
    public class ClientsViewModel
    {
        public ClientsWeb Clients { get; set; }
        public bool Authentifie { get; set; }

        public ClientsViewModel()
        {
            Authentifie = false;
        }
    }
}
