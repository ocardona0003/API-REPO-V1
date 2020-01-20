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
    [RoutePrefix("api/Calibre2Caras")]
    public class Calibre2CarasController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/Calibre2Caras
        public IQueryable<Calibre2Caras> GetCalibre2Caras()
        {
            return db.Calibre2Caras;
        }

        // GET: api/Calibre2Caras/5
        [ResponseType(typeof(Calibre2Caras))]
        public IHttpActionResult GetCalibre2Caras(int id)
        {
            Calibre2Caras calibre2Caras = db.Calibre2Caras.Find(id);
            if (calibre2Caras == null)
            {
                return NotFound();
            }

            return Ok(calibre2Caras);
        }

        // PUT: api/Calibre2Caras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalibre2Caras(Calibre2Caras calibre2Caras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (calibre2Caras.ultimoUsr == null || calibre2Caras.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            calibre2Caras.ultimaFec = DateTime.Now;

            db.Entry(calibre2Caras).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Calibre2CarasExists(calibre2Caras.idCalibre2Caras))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(calibre2Caras);
        }

        // POST: api/Calibre2Caras
        [ResponseType(typeof(Calibre2Caras))]
        public IHttpActionResult PostCalibre2Caras(Calibre2Caras calibre2Caras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (calibre2Caras.ultimoUsr == null || calibre2Caras.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            calibre2Caras.ultimaFec = DateTime.Now;

            db.Calibre2Caras.Add(calibre2Caras);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calibre2Caras.idCalibre2Caras }, calibre2Caras);
        }

        // DELETE: api/Calibre2Caras/5
        [ResponseType(typeof(Calibre2Caras))]
        public IHttpActionResult DeleteCalibre2Caras(int id)
        {
            Calibre2Caras calibre2Caras = db.Calibre2Caras.Find(id);
            if (calibre2Caras == null)
            {
                return NotFound();
            }

            db.Calibre2Caras.Remove(calibre2Caras);
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

        private bool Calibre2CarasExists(int id)
        {
            return db.Calibre2Caras.Count(e => e.idCalibre2Caras == id) > 0;
        }
    }
}