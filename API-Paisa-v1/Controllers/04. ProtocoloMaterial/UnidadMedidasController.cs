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
    [RoutePrefix("api/UnidadMedidas")]
    public class UnidadMedidasController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/UnidadMedidas
        public IQueryable<UnidadMedida> GetUnidadMedida()
        {
            return db.UnidadMedida;
        }

        // GET: api/UnidadMedidas/5
        [ResponseType(typeof(UnidadMedida))]
        public IHttpActionResult GetUnidadMedida(string id)
        {
            UnidadMedida unidadMedida = db.UnidadMedida.Find(id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            return Ok(unidadMedida);
        }

        // PUT: api/UnidadMedidas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnidadMedida(UnidadMedida unidadMedida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (unidadMedida.ultimoUsr == null || unidadMedida.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            unidadMedida.ultimaFec = DateTime.Now;

            db.Entry(unidadMedida).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadMedidaExists(unidadMedida.idUnidadMedida))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(unidadMedida);
        }

        // POST: api/UnidadMedidas
        [ResponseType(typeof(UnidadMedida))]
        public IHttpActionResult PostUnidadMedida(UnidadMedida unidadMedida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (unidadMedida.ultimoUsr == null || unidadMedida.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            unidadMedida.ultimaFec = DateTime.Now;

            db.UnidadMedida.Add(unidadMedida);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UnidadMedidaExists(unidadMedida.idUnidadMedida))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = unidadMedida.idUnidadMedida }, unidadMedida);
        }

        // DELETE: api/UnidadMedidas/5
        [ResponseType(typeof(UnidadMedida))]
        public IHttpActionResult DeleteUnidadMedida(string id)
        {
            UnidadMedida unidadMedida = db.UnidadMedida.Find(id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            db.UnidadMedida.Remove(unidadMedida);
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

        private bool UnidadMedidaExists(string id)
        {
            return db.UnidadMedida.Count(e => e.idUnidadMedida == id) > 0;
        }
    }
}