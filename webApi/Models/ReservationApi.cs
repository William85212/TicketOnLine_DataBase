using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class ReservationApi
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NbrPlace { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }
        public int PrixTotal { get; set; }
    }
}
