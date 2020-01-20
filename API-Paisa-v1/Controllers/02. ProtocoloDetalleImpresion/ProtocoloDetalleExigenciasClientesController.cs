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
    [RoutePrefix("api/ProtocoloDetalleExigenciasClientes")]
    public class ProtocoloDetalleExigenciasClientesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/ProtocoloDetalleExigenciasClientes
        public IQueryable<ProtocoloDetalleExigenciasCliente> GetProtocoloDetalleExigenciasCliente()
        {
            return db.ProtocoloDetalleExigenciasCliente;
        }

        // GET: api/ProtocoloDetalleExigenciasClientes/5
        [ResponseType(typeof(ProtocoloDetalleExigenciasCliente))]
        public IHttpActionResult GetProtocoloDetalleExigenciasCliente(int id)
        {
            ProtocoloDetalleExigenciasCliente protocoloDetalleExigenciasCliente = db.ProtocoloDetalleExigenciasCliente.Find(id);
            if (protocoloDetalleExigenciasCliente == null)
            {
                return NotFound();
            }

            return Ok(protocoloDetalleExigenciasCliente);
        }

        // PUT: api/ProtocoloDetalleExigenciasClientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProtocoloDetalleExigenciasCliente(ProtocoloDetalleExigenciasCliente protocoloDetalleExigenciasCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (protocoloDetalleExigenciasCliente.ultimoUsr == null || protocoloDetalleExigenciasCliente.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleExigenciasCliente.ultimaFec = DateTime.Now;

            db.Entry(protocoloDetalleExigenciasCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocoloDetalleExigenciasClienteExists(protocoloDetalleExigenciasCliente.idProtocoloDetExiCliente))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(protocoloDetalleExigenciasCliente);
        }

        // POST: api/ProtocoloDetalleExigenciasClientes
        [ResponseType(typeof(ProtocoloDetalleExigenciasCliente))]
        public IHttpActionResult PostProtocoloDetalleExigenciasCliente(ProtocoloDetalleExigenciasCliente protocoloDetalleExigenciasCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloDetalleExigenciasCliente.ultimoUsr == null || protocoloDetalleExigenciasCliente.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleExigenciasCliente.ultimaFec = DateTime.Now;

            db.ProtocoloDetalleExigenciasCliente.Add(protocoloDetalleExigenciasCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = protocoloDetalleExigenciasCliente.idProtocoloDetExiCliente }, protocoloDetalleExigenciasCliente);
        }

        // DELETE: api/ProtocoloDetalleExigenciasClientes/5
        [ResponseType(typeof(ProtocoloDetalleExigenciasCliente))]
        public IHttpActionResult DeleteProtocoloDetalleExigenciasCliente(int id)
        {
            ProtocoloDetalleExigenciasCliente protocoloDetalleExigenciasCliente = db.ProtocoloDetalleExigenciasCliente.Find(id);
            if (protocoloDetalleExigenciasCliente == null)
            {
                return NotFound();
            }

            db.ProtocoloDetalleExigenciasCliente.Remove(protocoloDetalleExigenciasCliente);
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

        private bool ProtocoloDetalleExigenciasClienteExists(int id)
        {
            return db.ProtocoloDetalleExigenciasCliente.Count(e => e.idProtocoloDetExiCliente == id) > 0;
        }
    }
}