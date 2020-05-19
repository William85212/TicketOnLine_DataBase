using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public bool Paier { get; set; }
        public int IdPaiement { get; set; }
        public bool EnvoieFactutre { get; set; }
    }
}
