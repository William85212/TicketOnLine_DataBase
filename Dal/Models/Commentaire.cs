using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class Commentaire
    {
        public int Id { get; set; }
        public string Commentaires { get; set; }
        public int Jaime { get; set; }
        public int JaimePas { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }

    }
}
