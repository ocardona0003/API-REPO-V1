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
using Newtonsoft.Json;

namespace API_Paisa_v1.Controllers
{
    [Authorize]
    [RoutePrefix("api/SEC_TipoUsuario")]
    public class SEC_TipoUsuarioController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/SEC_TipoUsuario
        public IQueryable<SEC_TipoUsuario> GetSEC_TipoUsuario()
        {
            return db.SEC_TipoUsuario;
        }

        // GET: api/SEC_TipoUsuario/5
        [ResponseType(typeof(SEC_TipoUsuario))]
        public IHttpActionResult GetSEC_TipoUsuario(int id)
        {
            SEC_TipoUsuario sEC_TipoUsuario = db.SEC_TipoUsuario.Find(id);
            if (sEC_TipoUsuario == null)
            {
                return NotFound();
            }

            return Ok(sEC_TipoUsuario);
        }

        // PUT: api/SEC_TipoUsuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSEC_TipoUsuario(SEC_TipoUsuario sEC_TipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            sEC_TipoUsuario.ultimaFecha = DateTime.Now;
            db.Entry(sEC_TipoUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SEC_TipoUsuarioExists(sEC_TipoUsuario.idTipoUsuario))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/SEC_TipoUsuario
        [ResponseType(typeof(SEC_TipoUsuario))]
        public IHttpActionResult PostSEC_TipoUsuario(SEC_TipoUsuario sEC_TipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            sEC_TipoUsuario.ultimaFecha = DateTime.Now;
            db.SEC_TipoUsuario.Add(sEC_TipoUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sEC_TipoUsuario.idTipoUsuario }, sEC_TipoUsuario);
        }

        // DELETE: api/SEC_TipoUsuario/5
        [ResponseType(typeof(SEC_TipoUsuario))]
        public IHttpActionResult DeleteSEC_TipoUsuario(int id)
        {
            SEC_TipoUsuario sEC_TipoUsuario = db.SEC_TipoUsuario.Find(id);
            if (sEC_TipoUsuario == null)
            {
                return NotFound();
            }

            db.SEC_TipoUsuario.Remove(sEC_TipoUsuario);
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

        private bool SEC_TipoUsuarioExists(int id)
        {
            return db.SEC_TipoUsuario.Count(e => e.idTipoUsuario == id) > 0;
        }
    }
}