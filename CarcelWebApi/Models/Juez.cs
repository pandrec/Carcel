using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarcelWebApi.Models
{
    [Table("Juez")]
    public class Juez
    {

        public int ID { get; set; }

        public string nombre { get; set; }

        public string Rut { get; set; }

        public bool Sexo { get; set; }

        public string Domicilio { get; set; }



    }
}