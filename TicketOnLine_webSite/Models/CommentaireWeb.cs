using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Models
{
    public class CommentaireWeb
    {
        public int Id { get; set; }
        public string Commentaires { get; set; }
        public int Jaime { get; set; }
        public int JaimePas { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }
    }
}
