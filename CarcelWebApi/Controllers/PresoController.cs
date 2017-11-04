using CarcelWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarcelWebApi.Controllers
{
    public class PresoController : ApiController
    {
        private CarcelDbContext context;

        public PresoController()
        {
            context = new CarcelDbContext();

        }
        
        public IEnumerable<Object> get()
        {
            return context.Preso.ToList();

        }

        public IHttpActionResult delete(int id)

        {
            Preso preso = context.Preso.Find(id);

            if (preso == null) return NotFound();//404

            context.Preso.Remove(preso);

            if (context.SaveChanges() > 0)
            {

                return Ok(new { Mensaje = " Eliminado Correctamente" });
            }

            return InternalServerError();

        }



        public IHttpActionResult post(Preso preso)
        {
            context.Preso.Add(preso);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "  Agregado correctamente" });

        }

        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();

        }
    }
}
