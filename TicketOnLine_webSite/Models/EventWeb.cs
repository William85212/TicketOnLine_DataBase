using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Models
{
    public class EventWeb
    {
        public int Id { get; set; }
        public string NomSpectacle { get; set; }
        public string Realisateur { get; set; }
        public string Description { get; set; }
        public long Duree { get; set; }
        public int PlaceRestante { get; set; }
        public int IdSalle { get; set; }
        public string Image { get; set; }
    }
}
