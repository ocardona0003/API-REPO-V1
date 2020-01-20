using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_Paisa_v1.Models;

namespace API_Paisa_v1.Controllers._04._ProtocoloMaterial
{
    [Authorize]
    [RoutePrefix("api/Presentaciones")]
    public class PresentacionesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/Presentaciones
        public IQueryable<Presentacion> GetPresentacion()
        {
            return db.Presentacion;
        }

        // GET: api/Presentaciones/5
        [ResponseType(typeof(Presentacion))]
        public IHttpActionResult GetPresentacion(string id)
        {
            Presentacion presentacion = db.Presentacion.Find(id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return Ok(presentacion);
        }

        // PUT: api/Presentaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPresentacion(Presentacion presentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (presentacion.ultimoUsr == null || presentacion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            presentacion.ultimaFec = DateTime.Now;

            db.Entry(presentacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionExists(presentacion.idPresentacion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(presentacion);
        }

        // POST: api/Presentaciones
        [ResponseType(typeof(Presentacion))]
        public IHttpActionResult PostPresentacion(Presentacion presentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Presentacion.Add(presentacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PresentacionExists(presentacion.idPresentacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = presentacion.idPresentacion }, presentacion);
        }

        // DELETE: api/Presentaciones/5
        [ResponseType(typeof(Presentacion))]
        public IHttpActionResult DeletePresentacion(string id)
        {
            Presentacion presentacion = db.Presentacion.Find(id);
            if (presentacion == null)
            {
                return NotFound();
            }

            db.Presentacion.Remove(presentacion);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PresentacionExists(string id)
        {
            return db.Presentacion.Count(e => e.idPresentacion == id) > 0;
        }
    }
}