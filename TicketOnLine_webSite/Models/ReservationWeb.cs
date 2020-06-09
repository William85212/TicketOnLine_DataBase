using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Models
{
    public class ReservationWeb
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int NbrPlace { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }
        public int PrixPlace { get; set; }
    }
}
