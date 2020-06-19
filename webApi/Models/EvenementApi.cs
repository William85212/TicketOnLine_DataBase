﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class EvenementApi
    {
        public int Id { get; set; }
        public string NomSpectacle { get; set; }
        public string Realisateur { get; set; }
        public string Description { get; set; }
        public long Duree { get; set; }
        public int PlaceRestante { get; set; }
        public string Image { get; set; }
        public int Prix { get; set; }
    }
}
