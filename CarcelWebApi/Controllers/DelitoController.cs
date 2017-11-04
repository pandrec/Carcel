using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarcelWebApi.Models;

namespace CarcelWebApi.Controllers
{
    public class DelitoController : ApiController
    {
        private CarcelDbContext context;

        public DelitoController()
        {
            context = new CarcelDbContext();

        }

        public IEnumerable<Object> get()
        {
            return context.Delito.ToList();
            


        }

        List<Preso> pressos = new List<Preso>()
        {
            new Preso() { Nombre="Juan", ID=1 , Apellido="Perez", Domicilio="jola", Rut="111111-0", Sexo=true },
            new Preso() { Nombre="marcelo",  ID=2 },
            new Preso() { Nombre="rodrigo", ID=3 }
        };


        public IHttpActionResult delete(int id)

        {
            Delito delito = context.Delito.Find(id);

            if (delito == null) return NotFound();//404

            context.Delito.Remove(delito);

            if(context.SaveChanges() >0)
            {

                return Ok(new { Mensaje = " Eliminado Correctamente" });
            }

            return InternalServerError();

        }



        public IHttpActionResult post(Delito delito)
        {
            context.Delito.Add(delito);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "  Agregado correctamente" });

        }

        public IHttpActionResult put(Delito delito)
        {
            context.Entry(delito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }


    }


}
