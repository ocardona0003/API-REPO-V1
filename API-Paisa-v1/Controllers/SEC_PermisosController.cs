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
    [RoutePrefix("api/SEC_Permisos")]
    public class SEC_PermisosController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/SEC_Permisos
        public IQueryable<SEC_Permisos> GetSEC_Permisos()
        {
            return db.SEC_Permisos;
        }

        // GET: api/SEC_Permisos/5
        [ResponseType(typeof(SEC_Permisos))]
        public IHttpActionResult GetSEC_Permisos(int id)
        {
            SEC_Permisos sEC_Permisos = db.SEC_Permisos.Find(id);
            if (sEC_Permisos == null)
            {
                return NotFound();
            }

            return Ok(sEC_Permisos);
        }

        // PUT: api/SEC_Permisos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSEC_Permisos(int id, SEC_Permisos sEC_Permisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sEC_Permisos.idPermiso)
            {
                return BadRequest();
            }
            sEC_Permisos.ultimaFecha = DateTime.Now;
            db.Entry(sEC_Permisos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SEC_PermisosExists(id))
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

        // POST: api/SEC_Permisos
        [ResponseType(typeof(SEC_Permisos))]
        public IHttpActionResult PostSEC_Permisos(SEC_Permisos sEC_Permisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            sEC_Permisos.ultimaFecha = DateTime.Now;
            db.SEC_Permisos.Add(sEC_Permisos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sEC_Permisos.idPermiso }, sEC_Permisos);
        }

        // DELETE: api/SEC_Permisos/5
        [ResponseType(typeof(SEC_Permisos))]
        public IHttpActionResult DeleteSEC_Permisos(int id)
        {
            SEC_Permisos sEC_Permisos = db.SEC_Permisos.Find(id);
            if (sEC_Permisos == null)
            {
                return NotFound();
            }

            db.SEC_Permisos.Remove(sEC_Permisos);
            db.SaveChanges();

            //return Ok(sEC_Permisos);
            return Ok("True");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SEC_PermisosExists(int id)
        {
            return db.SEC_Permisos.Count(e => e.idPermiso == id) > 0;
        }
    }
}