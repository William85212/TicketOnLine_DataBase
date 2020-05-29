using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.ViewModel
{
    public class ContinuerAchat
    {
        [System.ComponentModel.DataAnnotations.Display(Name ="Vouler vous continuer vos achat")]
        public bool go { get; set; }
    }
}
