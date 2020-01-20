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

namespace API_Paisa_v1.Controllers._03._ProtocoloEncabezados
{
    [Authorize]
    [RoutePrefix("api/TipoTapes")]
    public class TipoTapesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TipoTapes
        public IQueryable<TipoTape> GetTipoTape()
        {
            return db.TipoTape;
        }

        // GET: api/TipoTapes/5
        [ResponseType(typeof(TipoTape))]
        public IHttpActionResult GetTipoTape(int id)
        {
            TipoTape tipoTape = db.TipoTape.Find(id);
            if (tipoTape == null)
            {
                return NotFound();
            }

            return Ok(tipoTape);
        }

        // PUT: api/TipoTapes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoTape(TipoTape tipoTape)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoTape.ultimoUsr == null || tipoTape.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoTape.ultimaFec = DateTime.Now;

            db.Entry(tipoTape).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTapeExists(tipoTape.idTipoTape))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tipoTape);
        }

        // POST: api/TipoTapes
        [ResponseType(typeof(TipoTape))]
        public IHttpActionResult PostTipoTape(TipoTape tipoTape)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoTape.ultimoUsr == null || tipoTape.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoTape.ultimaFec = DateTime.Now;

            db.TipoTape.Add(tipoTape);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoTape.idTipoTape }, tipoTape);
        }

        // DELETE: api/TipoTapes/5
        [ResponseType(typeof(TipoTape))]
        public IHttpActionResult DeleteTipoTape(int id)
        {
            TipoTape tipoTape = db.TipoTape.Find(id);
            if (tipoTape == null)
            {
                return NotFound();
            }

            db.TipoTape.Remove(tipoTape);
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

        private bool TipoTapeExists(int id)
        {
            return db.TipoTape.Count(e => e.idTipoTape == id) > 0;
        }
    }
}