using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NbrPlace { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }
        public int PrixPlace { get; set; }
    }
}
