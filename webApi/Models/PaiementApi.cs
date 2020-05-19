using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class PaiementApi
    {
        public int Id { get; set; }
        public bool Paier { get; set; }
        public int IdPaiement { get; set; }
        public bool EnvoieFactutre { get; set; }
    }
}
