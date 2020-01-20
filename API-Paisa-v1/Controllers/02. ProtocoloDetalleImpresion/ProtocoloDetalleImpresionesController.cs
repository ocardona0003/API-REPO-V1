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

namespace API_Paisa_v1.Controllers._02._ProtocoloDetalleImpresion
{
    [Authorize]
    [RoutePrefix("api/ProtocoloDetalleImpresiones")]
    public class ProtocoloDetalleImpresionesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/ProtocoloDetalleImpresiones
        public IQueryable<ProtocoloDetalleImpresion> GetProtocoloDetalleImpresion()
        {
            return db.ProtocoloDetalleImpresion;
        }

        // GET: api/ProtocoloDetalleImpresiones/5
        [ResponseType(typeof(ProtocoloDetalleImpresion))]
        public IHttpActionResult GetProtocoloDetalleImpresion(int id)
        {
            ProtocoloDetalleImpresion protocoloDetalleImpresion = db.ProtocoloDetalleImpresion.Find(id);
            if (protocoloDetalleImpresion == null)
            {
                return NotFound();
            }

            return Ok(protocoloDetalleImpresion);
        }

        // PUT: api/ProtocoloDetalleImpresiones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProtocoloDetalleImpresion(ProtocoloDetalleImpresion protocoloDetalleImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          
            if (protocoloDetalleImpresion.ultimoUsr == null || protocoloDetalleImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleImpresion.ultimaFec = DateTime.Now;
            db.Entry(protocoloDetalleImpresion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocoloDetalleImpresionExists(protocoloDetalleImpresion.idProtocoloDetImpresion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(protocoloDetalleImpresion);
        }

        // POST: api/ProtocoloDetalleImpresiones
        [ResponseType(typeof(ProtocoloDetalleImpresion))]
        public IHttpActionResult PostProtocoloDetalleImpresion(ProtocoloDetalleImpresion protocoloDetalleImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (protocoloDetalleImpresion.ultimoUsr == null || protocoloDetalleImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleImpresion.ultimaFec = DateTime.Now;
            db.ProtocoloDetalleImpresion.Add(protocoloDetalleImpresion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = protocoloDetalleImpresion.idProtocoloDetImpresion }, protocoloDetalleImpresion);
        }

        // DELETE: api/ProtocoloDetalleImpresiones/5
        [ResponseType(typeof(ProtocoloDetalleImpresion))]
        public IHttpActionResult DeleteProtocoloDetalleImpresion(int id)
        {
            ProtocoloDetalleImpresion protocoloDetalleImpresion = db.ProtocoloDetalleImpresion.Find(id);
            if (protocoloDetalleImpresion == null)
            {
                return NotFound();
            }

            db.ProtocoloDetalleImpresion.Remove(protocoloDetalleImpresion);
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

        private bool ProtocoloDetalleImpresionExists(int id)
        {
            return db.ProtocoloDetalleImpresion.Count(e => e.idProtocoloDetImpresion == id) > 0;
        }
    }
}