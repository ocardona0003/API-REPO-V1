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
    [RoutePrefix("api/ProtocoloDetalleEmpaques")]
    public class ProtocoloDetalleEmpaquesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/ProtocoloDetalleEmpaques
        public IQueryable<ProtocoloDetalleEmpaque> GetProtocoloDetalleEmpaque()
        {
            return db.ProtocoloDetalleEmpaque;
        }

        // GET: api/ProtocoloDetalleEmpaques/5
        [ResponseType(typeof(ProtocoloDetalleEmpaque))]
        public IHttpActionResult GetProtocoloDetalleEmpaque(int id)
        {
            ProtocoloDetalleEmpaque protocoloDetalleEmpaque = db.ProtocoloDetalleEmpaque.Find(id);
            if (protocoloDetalleEmpaque == null)
            {
                return NotFound();
            }

            return Ok(protocoloDetalleEmpaque);
        }

        // PUT: api/ProtocoloDetalleEmpaques/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProtocoloDetalleEmpaque(ProtocoloDetalleEmpaque protocoloDetalleEmpaque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloDetalleEmpaque.ultimoUsr == null || protocoloDetalleEmpaque.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleEmpaque.ultimaFec = DateTime.Now;

            db.Entry(protocoloDetalleEmpaque).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocoloDetalleEmpaqueExists(protocoloDetalleEmpaque.idProtocoloDetEmpaque))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(protocoloDetalleEmpaque);
        }

        // POST: api/ProtocoloDetalleEmpaques
        [ResponseType(typeof(ProtocoloDetalleEmpaque))]
        public IHttpActionResult PostProtocoloDetalleEmpaque(ProtocoloDetalleEmpaque protocoloDetalleEmpaque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloDetalleEmpaque.ultimoUsr == null || protocoloDetalleEmpaque.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleEmpaque.ultimaFec = DateTime.Now;

            db.ProtocoloDetalleEmpaque.Add(protocoloDetalleEmpaque);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = protocoloDetalleEmpaque.idProtocoloDetEmpaque }, protocoloDetalleEmpaque);
        }

        // DELETE: api/ProtocoloDetalleEmpaques/5
        [ResponseType(typeof(ProtocoloDetalleEmpaque))]
        public IHttpActionResult DeleteProtocoloDetalleEmpaque(int id)
        {
            ProtocoloDetalleEmpaque protocoloDetalleEmpaque = db.ProtocoloDetalleEmpaque.Find(id);
            if (protocoloDetalleEmpaque == null)
            {
                return NotFound();
            }

            db.ProtocoloDetalleEmpaque.Remove(protocoloDetalleEmpaque);
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

        private bool ProtocoloDetalleEmpaqueExists(int id)
        {
            return db.ProtocoloDetalleEmpaque.Count(e => e.idProtocoloDetEmpaque == id) > 0;
        }
    }
}