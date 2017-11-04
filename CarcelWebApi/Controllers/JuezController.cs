using CarcelWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarcelWebApi.Controllers
{
    public class JuezController : ApiController
    {
        private CarcelDbContext context;

        public JuezController()
        {
            context = new CarcelDbContext();

        }

        public IEnumerable<Object> get()
        {
            return context.Juez.ToList();

        }

        public IHttpActionResult delete(int id)

        {
            Juez juez = context.Juez.Find(id);

            if (juez == null) return NotFound();//404

            context.Juez.Remove(juez);

            if (context.SaveChanges() > 0)
            {

                return Ok(new { Mensaje = " Eliminado Correctamente" });
            }

            return InternalServerError();

        }



        public IHttpActionResult post(Juez juez)
        {
            context.Juez.Add(juez);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "  Agregado correctamente" });

        }

        public IHttpActionResult put(Juez juez)
        {
            context.Entry(juez).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();
            
        }
    }
}
