using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class Salles
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Lieux { get; set; }
        public int Capacite { get; set; }
        public string Image { get; set; }
        public int IdEvent { get; set; }
        public int IdDateEvent { get; set; }

    }
}
