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
        public IHttpActionResult PutSEC_Usuario(sp_V_SEC_Usuario2_Result sEC_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sp_U_SEC_Usuario2(sEC_Usuario.idUsuario, sEC_Usuario.idTipoUsuario, sEC_Usuario.codUsuario, sEC_Usuario.pass, sEC_Usuario.nombreCompleto, sEC_Usuario.email, sEC_Usuario.activo, sEC_Usuario.ultimaFechaMod, sEC_Usuario.ultimoIngreso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SEC_UsuarioExists(sEC_Usuario.idUsuario))
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
        [ResponseType(typeof(sp_V_SEC_Usuario2_Result))]
        public IHttpActionResult PostSEC_Usuario(sp_V_SEC_Usuario2_Result sEC_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int? max = (from o in db.SEC_Usuario
                        select (int?)o.idUsuario).Max();

            sEC_Usuario.idUsuario = max.Value + 1;

            db.sp_I_SEC_Usuario3(sEC_Usuario.idTipoUsuario, sEC_Usuario.codUsuario, sEC_Usuario.pass, sEC_Usuario.nombreCompleto, sEC_Usuario.email, sEC_Usuario.activo, sEC_Usuario.ultimaFechaMod, sEC_Usuario.ultimoIngreso);

            return Ok(sEC_Usuario);
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

            return Ok(sEC_Usuario);
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