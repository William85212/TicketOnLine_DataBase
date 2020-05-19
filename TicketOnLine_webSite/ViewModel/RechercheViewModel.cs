using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.ViewModel
{
    public class RechercheViewModel
    {
        public List<EventWeb> SearchResult { get; set; }
        public String Search { get; set; }
    }
}
