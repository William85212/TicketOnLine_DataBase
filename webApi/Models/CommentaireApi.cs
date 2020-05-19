using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class CommentaireApi
    {
        public int Id { get; set; }
        public string Commentaires { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }

    }
}
