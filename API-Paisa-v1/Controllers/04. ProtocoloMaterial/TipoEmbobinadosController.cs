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
    [RoutePrefix("api/TipoEmbobinados")]
    public class TipoEmbobinadosController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TipoEmbobinados
        public IQueryable<TipoEmbobinado> GetTipoEmbobinado()
        {
            return db.TipoEmbobinado;
        }

        // GET: api/TipoEmbobinados/5
        [ResponseType(typeof(TipoEmbobinado))]
        public IHttpActionResult GetTipoEmbobinado(int id)
        {
            TipoEmbobinado tipoEmbobinado = db.TipoEmbobinado.Find(id);
            if (tipoEmbobinado == null)
            {
                return NotFound();
            }

            return Ok(tipoEmbobinado);
        }

        // PUT: api/TipoEmbobinados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoEmbobinado(TipoEmbobinado tipoEmbobinado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoEmbobinado.ultimoUsr == null || tipoEmbobinado.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoEmbobinado.ultimaFec = DateTime.Now;

            db.Entry(tipoEmbobinado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEmbobinadoExists(tipoEmbobinado.idTipoEmbobinado))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tipoEmbobinado);
        }

        // POST: api/TipoEmbobinados
        [ResponseType(typeof(TipoEmbobinado))]
        public IHttpActionResult PostTipoEmbobinado(TipoEmbobinado tipoEmbobinado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoEmbobinado.ultimoUsr == null || tipoEmbobinado.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoEmbobinado.ultimaFec = DateTime.Now;

            db.TipoEmbobinado.Add(tipoEmbobinado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoEmbobinado.idTipoEmbobinado }, tipoEmbobinado);
        }

        // DELETE: api/TipoEmbobinados/5
        [ResponseType(typeof(TipoEmbobinado))]
        public IHttpActionResult DeleteTipoEmbobinado(int id)
        {
            TipoEmbobinado tipoEmbobinado = db.TipoEmbobinado.Find(id);
            if (tipoEmbobinado == null)
            {
                return NotFound();
            }

            db.TipoEmbobinado.Remove(tipoEmbobinado);
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

        private bool TipoEmbobinadoExists(int id)
        {
            return db.TipoEmbobinado.Count(e => e.idTipoEmbobinado == id) > 0;
        }
    }
}