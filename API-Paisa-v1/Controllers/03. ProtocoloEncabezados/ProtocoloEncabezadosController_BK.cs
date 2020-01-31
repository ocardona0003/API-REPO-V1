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
    [RoutePrefix("api/ProtocoloEncabezados")]
    public class ProtocoloEncabezadosController_BK : ApiController
    {        
        private paisaEntities db = new paisaEntities();

        // GET: api/ProtocoloEncabezados
        public IQueryable<ProtocoloEncabezado> GetProtocoloEncabezado()
        {
            return db.ProtocoloEncabezado;
        }

        // GET: api/ProtocoloEncabezados/5
        [ResponseType(typeof(ProtocoloEncabezado))]
        public IHttpActionResult GetProtocoloEncabezado(int id)
        {
            ProtocoloEncabezado protocoloEncabezado = db.ProtocoloEncabezado.Find(id);
            if (protocoloEncabezado == null)
            {
                return NotFound();
            }

            return Ok(protocoloEncabezado);
        }

        // PUT: api/ProtocoloEncabezados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProtocoloEncabezado(ProtocoloEncabezado protocoloEncabezado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloEncabezado.ultimoUsr == null || protocoloEncabezado.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloEncabezado.ultimaFec = DateTime.Now;

            db.Entry(protocoloEncabezado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocoloEncabezadoExists(protocoloEncabezado.IdEncabezado))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(protocoloEncabezado);
        }

        // POST: api/ProtocoloEncabezados
        [ResponseType(typeof(ProtocoloEncabezado))]
        public IHttpActionResult PostProtocoloEncabezado(ProtocoloEncabezado protocoloEncabezado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloEncabezado.ultimoUsr == null || protocoloEncabezado.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloEncabezado.ultimaFec = DateTime.Now;

            db.ProtocoloEncabezado.Add(protocoloEncabezado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = protocoloEncabezado.IdEncabezado }, protocoloEncabezado);
        }

        // DELETE: api/ProtocoloEncabezados/5
        [ResponseType(typeof(ProtocoloEncabezado))]
        public IHttpActionResult DeleteProtocoloEncabezado(int id)
        {
            ProtocoloEncabezado protocoloEncabezado = db.ProtocoloEncabezado.Find(id);
            if (protocoloEncabezado == null)
            {
                return NotFound();
            }

            db.ProtocoloEncabezado.Remove(protocoloEncabezado);
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

        private bool ProtocoloEncabezadoExists(int id)
        {
            return db.ProtocoloEncabezado.Count(e => e.IdEncabezado == id) > 0;
        }
    }
}