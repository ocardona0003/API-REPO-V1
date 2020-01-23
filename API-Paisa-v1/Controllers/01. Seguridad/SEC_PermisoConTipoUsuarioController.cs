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
    [RoutePrefix("api/SEC_PermisoConTipoUsuario")]
    public class SEC_PermisoConTipoUsuarioController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/SEC_PermisoConTipoUsuario
        public IQueryable<SEC_PermisoConTipoUsuario> GetSEC_PermisoConTipoUsuario()
        {
            return db.SEC_PermisoConTipoUsuario;
        }

        // GET: api/SEC_PermisoConTipoUsuario/5
        [ResponseType(typeof(SEC_PermisoConTipoUsuario))]
        public IHttpActionResult GetSEC_PermisoConTipoUsuario(int id)
        {
            var data = db.SP_P_SEC_PermisosXUsuario(id);
            //SEC_PermisoConTipoUsuario sEC_PermisoConTipoUsuario = db.SEC_PermisoConTipoUsuario.Find(id);
            //if (sEC_PermisoConTipoUsuario == null)
            //{
            //    return NotFound();
            //}

            return Ok(data);
        }

        // PUT: api/SEC_PermisoConTipoUsuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSEC_PermisoConTipoUsuario(SEC_PermisoConTipoUsuario sEC_PermisoConTipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

 
            db.Entry(sEC_PermisoConTipoUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SEC_PermisoConTipoUsuarioExists(sEC_PermisoConTipoUsuario.idPermisoConTipoUsuario))
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

        // POST: api/SEC_PermisoConTipoUsuario
        [ResponseType(typeof(SEC_PermisoConTipoUsuario))]
        public IHttpActionResult PostSEC_PermisoConTipoUsuario(SEC_PermisoConTipoUsuario sEC_PermisoConTipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SEC_PermisoConTipoUsuario.Add(sEC_PermisoConTipoUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sEC_PermisoConTipoUsuario.idPermisoConTipoUsuario }, sEC_PermisoConTipoUsuario);
        }

        // DELETE: api/SEC_PermisoConTipoUsuario/5
        [ResponseType(typeof(SEC_PermisoConTipoUsuario))]
        public IHttpActionResult DeleteSEC_PermisoConTipoUsuario(int id)
        {
            SEC_PermisoConTipoUsuario sEC_PermisoConTipoUsuario = db.SEC_PermisoConTipoUsuario.Find(id);
            if (sEC_PermisoConTipoUsuario == null)
            {
                return NotFound();
            }

            db.SEC_PermisoConTipoUsuario.Remove(sEC_PermisoConTipoUsuario);
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

        private bool SEC_PermisoConTipoUsuarioExists(int id)
        {
            return db.SEC_PermisoConTipoUsuario.Count(e => e.idPermisoConTipoUsuario == id) > 0;
        }
    }
}