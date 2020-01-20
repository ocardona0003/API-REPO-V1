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
    [RoutePrefix("api/AnchoSinFuelles")]
    public class AnchoSinFuellesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/AnchoSinFuelles
        public IQueryable<AnchoSinFuelles> GetAnchoSinFuelles()
        {
            return db.AnchoSinFuelles;
        }

        // GET: api/AnchoSinFuelles/5
        [ResponseType(typeof(AnchoSinFuelles))]
        public IHttpActionResult GetAnchoSinFuelles(int id)
        {
            AnchoSinFuelles anchoSinFuelles = db.AnchoSinFuelles.Find(id);
            if (anchoSinFuelles == null)
            {
                return NotFound();
            }

            return Ok(anchoSinFuelles);
        }

        // PUT: api/AnchoSinFuelles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnchoSinFuelles(AnchoSinFuelles anchoSinFuelles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (anchoSinFuelles.ultimoUsr == null || anchoSinFuelles.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            anchoSinFuelles.ultimaFec = DateTime.Now;

            db.Entry(anchoSinFuelles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnchoSinFuellesExists(anchoSinFuelles.idAnchoSinFuelles))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(anchoSinFuelles);
        }

        // POST: api/AnchoSinFuelles
        [ResponseType(typeof(AnchoSinFuelles))]
        public IHttpActionResult PostAnchoSinFuelles(AnchoSinFuelles anchoSinFuelles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (anchoSinFuelles.ultimoUsr == null || anchoSinFuelles.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            anchoSinFuelles.ultimaFec = DateTime.Now;

            db.AnchoSinFuelles.Add(anchoSinFuelles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = anchoSinFuelles.idAnchoSinFuelles }, anchoSinFuelles);
        }

        // DELETE: api/AnchoSinFuelles/5
        [ResponseType(typeof(AnchoSinFuelles))]
        public IHttpActionResult DeleteAnchoSinFuelles(int id)
        {
            AnchoSinFuelles anchoSinFuelles = db.AnchoSinFuelles.Find(id);
            if (anchoSinFuelles == null)
            {
                return NotFound();
            }

            db.AnchoSinFuelles.Remove(anchoSinFuelles);
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

        private bool AnchoSinFuellesExists(int id)
        {
            return db.AnchoSinFuelles.Count(e => e.idAnchoSinFuelles == id) > 0;
        }
    }
}