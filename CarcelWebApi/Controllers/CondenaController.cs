using CarcelWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarcelWebApi.Controllers
{
    public class CondenaController : ApiController
    {
        private CarcelDbContext context;

        public CondenaController()
        {
            context = new CarcelDbContext();

        }

        public IEnumerable<Object> get()
        {
            return context.Condenas.Include("Condenas").Select(c => new
            {
                Id = c.ID,
                FechaInicioCondena = c.FechaInicioCondena,
                FechaCondena = c.FechaCondena,
                Juez = new
                {
                    Nombre = c.Juez.nombre,
                    Rut = c.Juez.Rut,
                    Sexo = c.Juez.Sexo,
                    Domicilio = c.Juez.Domicilio
                },
                Preso =  new
                {
                    Rut = c.Preso.Rut,
                    Nombre = c.Preso.Nombre,
                    Apellido = c.Preso.Apellido,
                    FechaNacimiento = c.Preso.FechaNacimiento,
                    Domicilio = c.Preso.Domicilio,
                    Sexo = c.Preso.Sexo
                }

            });
        }

        List<Preso> pressos = new List<Preso>()
        {
            new Preso() { Nombre="Juan", ID=1 , Apellido="Perez", Domicilio="jola", Rut="111111-0", Sexo=true },
            new Preso() { Nombre="marcelo",  ID=2 },
            new Preso() { Nombre="rodrigo", ID=3 }
        };


        public IHttpActionResult delete(int id)

        {
            Condena condena = context.Condenas.Find(id);

            if (condena == null) return NotFound();//404

            context.Condenas.Remove(condena);

            if (context.SaveChanges() > 0)
            {

                return Ok(new { Mensaje = " Eliminado Correctamente" });
            }

            return InternalServerError();

        }



        public IHttpActionResult post(Condena condena)
        {
            context.Condenas.Add(condena);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "  Agregado correctamente" });

        }

        public IHttpActionResult put(Condena condena)
        {
            context.Entry(condena).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

    }
}
