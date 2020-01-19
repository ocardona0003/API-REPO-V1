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
    [RoutePrefix("api/SEC_Usuario")]
    public class SEC_UsuarioController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/SEC_Usuario
        public IQueryable<SEC_Usuario> GetSEC_Usuario()
        {
            return db.SEC_Usuario;
        }

        // GET: api/SEC_Usuario/5
        [ResponseType(typeof(SEC_Usuario))]
        public IHttpActionResult GetSEC_Usuario(int id)
        {
            SEC_Usuario sEC_Usuario = db.SEC_Usuario.Find(id);
            if (sEC_Usuario == null)
            {
                return NotFound();
            }

            return Ok(sEC_Usuario);
        }

        // PUT: api/SEC_Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSEC_Usuario(int id, SEC_Usuario sEC_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sEC_Usuario.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(sEC_Usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SEC_UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(sEC_Usuario);
        }

        // POST: api/SEC_Usuario
        [ResponseType(typeof(SEC_Usuario))]
        public IHttpActionResult PostSEC_Usuario(SEC_Usuario sEC_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SEC_Usuario.Add(sEC_Usuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sEC_Usuario.idUsuario }, sEC_Usuario);
        }

        // DELETE: api/SEC_Usuario/5
        [ResponseType(typeof(SEC_Usuario))]
        public IHttpActionResult DeleteSEC_Usuario(int id)
        {
            SEC_Usuario sEC_Usuario = db.SEC_Usuario.Find(id);
            if (sEC_Usuario == null)
            {
                return NotFound();
            }

            db.SEC_Usuario.Remove(sEC_Usuario);
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

        private bool SEC_UsuarioExists(int id)
        {
            return db.SEC_Usuario.Count(e => e.idUsuario == id) > 0;
        }
    }
}