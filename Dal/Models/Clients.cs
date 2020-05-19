using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom{ get; set; }
        public DateTime DateNaisance { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }

    }
}
