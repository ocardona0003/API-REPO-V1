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

namespace API_Paisa_v1.Controllers._03._ProtocoloEncabezados
{
    [Authorize]
    [RoutePrefix("api/TipoExigencias")]
    public class TipoExigenciasController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TipoExigencias
        public IQueryable<TipoExigencia> GetTipoExigencia()
        {
            return db.TipoExigencia;
        }

        // GET: api/TipoExigencias/5
        [ResponseType(typeof(TipoExigencia))]
        public IHttpActionResult GetTipoExigencia(int id)
        {
            TipoExigencia tipoExigencia = db.TipoExigencia.Find(id);
            if (tipoExigencia == null)
            {
                return NotFound();
            }

            return Ok(tipoExigencia);
        }

        // PUT: api/TipoExigencias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoExigencia(TipoExigencia tipoExigencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoExigencia.ultimoUsr == null || tipoExigencia.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoExigencia.ultimaFec = DateTime.Now;

            db.Entry(tipoExigencia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExigenciaExists(tipoExigencia.idTipoExigencia))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tipoExigencia);
        }

        // POST: api/TipoExigencias
        [ResponseType(typeof(TipoExigencia))]
        public IHttpActionResult PostTipoExigencia(TipoExigencia tipoExigencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoExigencia.ultimoUsr == null || tipoExigencia.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoExigencia.ultimaFec = DateTime.Now;

            db.TipoExigencia.Add(tipoExigencia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoExigencia.idTipoExigencia }, tipoExigencia);
        }

        // DELETE: api/TipoExigencias/5
        [ResponseType(typeof(TipoExigencia))]
        public IHttpActionResult DeleteTipoExigencia(int id)
        {
            TipoExigencia tipoExigencia = db.TipoExigencia.Find(id);
            if (tipoExigencia == null)
            {
                return NotFound();
            }

            db.TipoExigencia.Remove(tipoExigencia);
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

        private bool TipoExigenciaExists(int id)
        {
            return db.TipoExigencia.Count(e => e.idTipoExigencia == id) > 0;
        }
    }
}