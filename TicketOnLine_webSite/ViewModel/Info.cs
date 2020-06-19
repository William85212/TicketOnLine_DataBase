using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.ViewModel
{
    public class Info
    {
        public int MontantTotal { get; set; }
        public string MoyenDePaiement { get; set; }
    }

    public enum Banque
    {
        Ing,
        Fortis,
        Dexia
    }
}
