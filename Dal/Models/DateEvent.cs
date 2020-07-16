using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class DateEvent
    {
        public int Id { get; set; }
        public DateTime DateRepresentation { get; set; }
        public int IdSalle { get; set; }
        public int IdEvent { get; set; }
        public int PlaceRestante { get; set; }
        public int PrixPlace { get; set; }
    }
}

