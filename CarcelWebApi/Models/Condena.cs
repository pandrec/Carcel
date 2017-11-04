using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelWebApi.Models
{
    [Table("Condena")]
    public class Condena
    {
        public int ID { get; set; }

        public DateTime FechaInicioCondena { get; set; }

        public DateTime FechaCondena { get; set; }

        public int? PresoId { get; set; }

        public int? JuezId { get; set; }

        public List<Delito> Delitos { get; set; }

        public Juez Juez { get; set; }

        public Preso Preso { get; set; }

    }
}