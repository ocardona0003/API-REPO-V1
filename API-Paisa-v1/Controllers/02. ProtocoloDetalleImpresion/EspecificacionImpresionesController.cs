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
    [RoutePrefix("api/EspecificacionImpresiones")]
    public class EspecificacionImpresionesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/EspecificacionImpresiones
        public IQueryable<EspecificacionImpresion> GetEspecificacionImpresion()
        {
            return db.EspecificacionImpresion;
        }

        // GET: api/EspecificacionImpresiones/5
        [ResponseType(typeof(EspecificacionImpresion))]
        public IHttpActionResult GetEspecificacionImpresion(int id)
        {
            EspecificacionImpresion especificacionImpresion = db.EspecificacionImpresion.Find(id);
            if (especificacionImpresion == null)
            {
                return NotFound();
            }

            return Ok(especificacionImpresion);
        }

        // PUT: api/EspecificacionImpresiones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEspecificacionImpresion(EspecificacionImpresion especificacionImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (especificacionImpresion.ultimoUsr == null || especificacionImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            especificacionImpresion.ultimaFec = DateTime.Now;
            db.Entry(especificacionImpresion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecificacionImpresionExists(especificacionImpresion.idEspecificacionImpresion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(especificacionImpresion);
        }

        // POST: api/EspecificacionImpresiones
        [ResponseType(typeof(EspecificacionImpresion))]
        public IHttpActionResult PostEspecificacionImpresion(EspecificacionImpresion especificacionImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (especificacionImpresion.ultimoUsr == null || especificacionImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            especificacionImpresion.ultimaFec = DateTime.Now;
            db.EspecificacionImpresion.Add(especificacionImpresion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = especificacionImpresion.idEspecificacionImpresion }, especificacionImpresion);
        }

        // DELETE: api/EspecificacionImpresiones/5
        [ResponseType(typeof(EspecificacionImpresion))]
        public IHttpActionResult DeleteEspecificacionImpresion(int id)
        {
            EspecificacionImpresion especificacionImpresion = db.EspecificacionImpresion.Find(id);
            if (especificacionImpresion == null)
            {
                return NotFound();
            }

            db.EspecificacionImpresion.Remove(especificacionImpresion);
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

        private bool EspecificacionImpresionExists(int id)
        {
            return db.EspecificacionImpresion.Count(e => e.idEspecificacionImpresion == id) > 0;
        }
    }
}