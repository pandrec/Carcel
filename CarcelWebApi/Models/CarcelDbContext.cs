using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarcelWebApi.Models
{
    public class CarcelDbContext:DbContext
    {

        public DbSet<Condena> Condenas { get; set; }

        public DbSet<CondenaDelito> CondenaDelito { get; set; }

        public DbSet<Delito> Delito { get; set; }

        public DbSet<Juez> Juez { get; set; }

        public DbSet<Preso> Preso { get; set; }


    }
}