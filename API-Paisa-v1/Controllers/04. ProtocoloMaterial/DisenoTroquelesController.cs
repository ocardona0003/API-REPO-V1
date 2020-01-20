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
    [RoutePrefix("api/DisenoTroqueles")]
    public class DisenoTroquelesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/DisenoTroqueles
        public IQueryable<DisenoTroquel> GetDisenoTroquel()
        {
            return db.DisenoTroquel;
        }

        // GET: api/DisenoTroqueles/5
        [ResponseType(typeof(DisenoTroquel))]
        public IHttpActionResult GetDisenoTroquel(int id)
        {
            DisenoTroquel disenoTroquel = db.DisenoTroquel.Find(id);
            if (disenoTroquel == null)
            {
                return NotFound();
            }

            return Ok(disenoTroquel);
        }

        // PUT: api/DisenoTroqueles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDisenoTroquel(DisenoTroquel disenoTroquel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (disenoTroquel.ultimoUsr == null || disenoTroquel.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            disenoTroquel.ultimaFec = DateTime.Now;

            db.Entry(disenoTroquel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisenoTroquelExists(disenoTroquel.idDisenoTroquel))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(disenoTroquel);
        }

        // POST: api/DisenoTroqueles
        [ResponseType(typeof(DisenoTroquel))]
        public IHttpActionResult PostDisenoTroquel(DisenoTroquel disenoTroquel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (disenoTroquel.ultimoUsr == null || disenoTroquel.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            disenoTroquel.ultimaFec = DateTime.Now;

            db.DisenoTroquel.Add(disenoTroquel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = disenoTroquel.idDisenoTroquel }, disenoTroquel);
        }

        // DELETE: api/DisenoTroqueles/5
        [ResponseType(typeof(DisenoTroquel))]
        public IHttpActionResult DeleteDisenoTroquel(int id)
        {
            DisenoTroquel disenoTroquel = db.DisenoTroquel.Find(id);
            if (disenoTroquel == null)
            {
                return NotFound();
            }

            db.DisenoTroquel.Remove(disenoTroquel);
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

        private bool DisenoTroquelExists(int id)
        {
            return db.DisenoTroquel.Count(e => e.idDisenoTroquel == id) > 0;
        }
    }
}