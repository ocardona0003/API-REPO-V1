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

namespace API_Paisa_v1.Controllers
{
    [Authorize]
    [RoutePrefix("api/TipoImpresion")]
    public class TipoImpresionController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TipoImpresion
        public IQueryable<TipoImpresion> GetTipoImpresion()
        {
            return db.TipoImpresion;
        }

        // GET: api/TipoImpresion/5
        [ResponseType(typeof(TipoImpresion))]
        public IHttpActionResult GetTipoImpresion(int id)
        {
            TipoImpresion tipoImpresion = db.TipoImpresion.Find(id);
            if (tipoImpresion == null)
            {
                return NotFound();
            }

            return Ok(tipoImpresion);
        }

        // PUT: api/TipoImpresion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoImpresion(int id, TipoImpresion tipoImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoImpresion.idTipoImpresion)
            {
                return BadRequest();
            }

            db.Entry(tipoImpresion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoImpresionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TipoImpresion
        [ResponseType(typeof(TipoImpresion))]
        public IHttpActionResult PostTipoImpresion(TipoImpresion tipoImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tipoImpresion.usuarioCrea.Equals(0) ||  tipoImpresion.usuarioCrea.Equals(null))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            tipoImpresion.fechaCrea = DateTime.Now;
            db.TipoImpresion.Add(tipoImpresion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoImpresion.idTipoImpresion }, tipoImpresion);
        }

        // DELETE: api/TipoImpresion/5
        [ResponseType(typeof(TipoImpresion))]
        public IHttpActionResult DeleteTipoImpresion(int id)
        {
            TipoImpresion tipoImpresion = db.TipoImpresion.Find(id);
            if (tipoImpresion == null)
            {
                return NotFound();
            }

            db.TipoImpresion.Remove(tipoImpresion);
            db.SaveChanges();

            return Ok(tipoImpresion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoImpresionExists(int id)
        {
            return db.TipoImpresion.Count(e => e.idTipoImpresion == id) > 0;
        }
    }
}