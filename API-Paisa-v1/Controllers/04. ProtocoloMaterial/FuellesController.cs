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
    [RoutePrefix("api/Fuelles")]
    public class FuellesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/Fuelles
        public IQueryable<Fuelle> GetFuelle()
        {
            return db.Fuelle;
        }

        // GET: api/Fuelles/5
        [ResponseType(typeof(Fuelle))]
        public IHttpActionResult GetFuelle(int id)
        {
            Fuelle fuelle = db.Fuelle.Find(id);
            if (fuelle == null)
            {
                return NotFound();
            }

            return Ok(fuelle);
        }

        // PUT: api/Fuelles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuelle(Fuelle fuelle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (fuelle.ultimoUsr == null || fuelle.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            fuelle.ultimaFec = DateTime.Now;

            db.Entry(fuelle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelleExists(fuelle.idFuelle))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(fuelle);
        }

        // POST: api/Fuelles
        [ResponseType(typeof(Fuelle))]
        public IHttpActionResult PostFuelle(Fuelle fuelle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (fuelle.ultimoUsr == null || fuelle.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }

            fuelle.ultimaFec = DateTime.Now;
            db.Fuelle.Add(fuelle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fuelle.idFuelle }, fuelle);
        }

        // DELETE: api/Fuelles/5
        [ResponseType(typeof(Fuelle))]
        public IHttpActionResult DeleteFuelle(int id)
        {
            Fuelle fuelle = db.Fuelle.Find(id);
            if (fuelle == null)
            {
                return NotFound();
            }

            db.Fuelle.Remove(fuelle);
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

        private bool FuelleExists(int id)
        {
            return db.Fuelle.Count(e => e.idFuelle == id) > 0;
        }
    }
}