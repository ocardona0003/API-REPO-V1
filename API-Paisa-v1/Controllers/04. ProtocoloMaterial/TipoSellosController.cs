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
    [RoutePrefix("api/TipoSellos")]
    public class TipoSellosController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TipoSellos
        public IQueryable<TipoSello> GetTipoSello()
        {
            return db.TipoSello;
        }

        // GET: api/TipoSellos/5
        [ResponseType(typeof(TipoSello))]
        public IHttpActionResult GetTipoSello(string id)
        {
            TipoSello tipoSello = db.TipoSello.Find(id);
            if (tipoSello == null)
            {
                return NotFound();
            }

            return Ok(tipoSello);
        }

        // PUT: api/TipoSellos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoSello(TipoSello tipoSello)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoSello.ultimoUsr == null || tipoSello.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoSello.ultimaFec = DateTime.Now;

            db.Entry(tipoSello).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSelloExists(tipoSello.idTipoSello))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tipoSello);
        }

        // POST: api/TipoSellos
        [ResponseType(typeof(TipoSello))]
        public IHttpActionResult PostTipoSello(TipoSello tipoSello)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoSello.Add(tipoSello);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TipoSelloExists(tipoSello.idTipoSello))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipoSello.idTipoSello }, tipoSello);
        }

        // DELETE: api/TipoSellos/5
        [ResponseType(typeof(TipoSello))]
        public IHttpActionResult DeleteTipoSello(string id)
        {
            TipoSello tipoSello = db.TipoSello.Find(id);
            if (tipoSello == null)
            {
                return NotFound();
            }

            db.TipoSello.Remove(tipoSello);
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

        private bool TipoSelloExists(string id)
        {
            return db.TipoSello.Count(e => e.idTipoSello == id) > 0;
        }
    }
}