namespace CarcelWebApi.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarcelWebApi.Models.CarcelDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarcelWebApi.Models.CarcelDbContext context)
        {
            context.Delito.AddOrUpdate(
                  d => d.Nombre,
                  new Delito { Nombre = "Homicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                  new Delito { Nombre = "Femicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                  new Delito { Nombre = "Robo con intimidadción", CondenaMinima = 1, CondenaMaxima = 12 },
                  new Delito { Nombre = "Robo en lugar no habitado", CondenaMinima = 1, CondenaMaxima = 5 },
                  new Delito { Nombre = "Cohecho", CondenaMinima = 5, CondenaMaxima = 8 }
               );
            
        }
    }
}
