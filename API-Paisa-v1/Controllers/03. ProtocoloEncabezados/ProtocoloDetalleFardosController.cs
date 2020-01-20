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
    [RoutePrefix("api/ProtocoloDetalleExigenciasClientes")]
    public class ProtocoloDetalleFardosController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/ProtocoloDetalleFardos
        public IQueryable<ProtocoloDetalleFardo> GetProtocoloDetalleFardo()
        {
            return db.ProtocoloDetalleFardo;
        }

        // GET: api/ProtocoloDetalleFardos/5
        [ResponseType(typeof(ProtocoloDetalleFardo))]
        public IHttpActionResult GetProtocoloDetalleFardo(int id)
        {
            ProtocoloDetalleFardo protocoloDetalleFardo = db.ProtocoloDetalleFardo.Find(id);
            if (protocoloDetalleFardo == null)
            {
                return NotFound();
            }

            return Ok(protocoloDetalleFardo);
        }

        // PUT: api/ProtocoloDetalleFardos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProtocoloDetalleFardo(ProtocoloDetalleFardo protocoloDetalleFardo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloDetalleFardo.ultimoUsr == null || protocoloDetalleFardo.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleFardo.ultimaFec = DateTime.Now;

            db.Entry(protocoloDetalleFardo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocoloDetalleFardoExists(protocoloDetalleFardo.idProtocoloDetFardo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(protocoloDetalleFardo);
        }

        // POST: api/ProtocoloDetalleFardos
        [ResponseType(typeof(ProtocoloDetalleFardo))]
        public IHttpActionResult PostProtocoloDetalleFardo(ProtocoloDetalleFardo protocoloDetalleFardo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloDetalleFardo.ultimoUsr == null || protocoloDetalleFardo.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleFardo.ultimaFec = DateTime.Now;

            db.ProtocoloDetalleFardo.Add(protocoloDetalleFardo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = protocoloDetalleFardo.idProtocoloDetFardo }, protocoloDetalleFardo);
        }

        // DELETE: api/ProtocoloDetalleFardos/5
        [ResponseType(typeof(ProtocoloDetalleFardo))]
        public IHttpActionResult DeleteProtocoloDetalleFardo(int id)
        {
            ProtocoloDetalleFardo protocoloDetalleFardo = db.ProtocoloDetalleFardo.Find(id);
            if (protocoloDetalleFardo == null)
            {
                return NotFound();
            }

            db.ProtocoloDetalleFardo.Remove(protocoloDetalleFardo);
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

        private bool ProtocoloDetalleFardoExists(int id)
        {
            return db.ProtocoloDetalleFardo.Count(e => e.idProtocoloDetFardo == id) > 0;
        }
    }
}