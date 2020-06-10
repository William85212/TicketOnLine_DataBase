using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Models
{
    public class ClientsWeb
    {
       // [Required]
        public int Id { get; set; }
       // [Required]
        public string Nom { get; set; }
        //[Required]
        public string Prenom { get; set; }
        //[Required]
        public DateTime DateNaisance { get; set; }
        //[Required]
        public string Sexe { get; set; }
        //[Required]
        public string Adresse { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        public bool IsActive { get; set; }
       // [Required]
        public bool IsAdmin { get; set; }
        //[Required]
        public string Password { get; set; }
    }

    public enum Gender
    {
        M,
        F,
        X
    }
}
