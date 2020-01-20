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
    [RoutePrefix("api/LargoSinFuelles")]
    public class LargoSinFuellesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/LargoSinFuelles
        public IQueryable<LargoSinFuelles> GetLargoSinFuelles()
        {
            return db.LargoSinFuelles;
        }

        // GET: api/LargoSinFuelles/5
        [ResponseType(typeof(LargoSinFuelles))]
        public IHttpActionResult GetLargoSinFuelles(int id)
        {
            LargoSinFuelles largoSinFuelles = db.LargoSinFuelles.Find(id);
            if (largoSinFuelles == null)
            {
                return NotFound();
            }

            return Ok(largoSinFuelles);
        }

        // PUT: api/LargoSinFuelles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLargoSinFuelles(LargoSinFuelles largoSinFuelles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (largoSinFuelles.ultimoUsr == null || largoSinFuelles.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            largoSinFuelles.ultimaFec = DateTime.Now;

            db.Entry(largoSinFuelles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LargoSinFuellesExists(largoSinFuelles.idLargoSinFuelles))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(largoSinFuelles);
        }

        // POST: api/LargoSinFuelles
        [ResponseType(typeof(LargoSinFuelles))]
        public IHttpActionResult PostLargoSinFuelles(LargoSinFuelles largoSinFuelles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LargoSinFuelles.Add(largoSinFuelles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = largoSinFuelles.idLargoSinFuelles }, largoSinFuelles);
        }

        // DELETE: api/LargoSinFuelles/5
        [ResponseType(typeof(LargoSinFuelles))]
        public IHttpActionResult DeleteLargoSinFuelles(int id)
        {
            LargoSinFuelles largoSinFuelles = db.LargoSinFuelles.Find(id);
            if (largoSinFuelles == null)
            {
                return NotFound();
            }

            db.LargoSinFuelles.Remove(largoSinFuelles);
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

        private bool LargoSinFuellesExists(int id)
        {
            return db.LargoSinFuelles.Count(e => e.idLargoSinFuelles == id) > 0;
        }
    }
}