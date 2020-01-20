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

namespace API_Paisa_v1.Controllers._04._ProtocoloMaterial
{
    [Authorize]
    [RoutePrefix("api/ProtocoloDetalleMateriales")]
    public class ProtocoloDetalleMaterialesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/ProtocoloDetalleMateriales
        public IQueryable<ProtocoloDetalleMaterial> GetProtocoloDetalleMaterial()
        {
            return db.ProtocoloDetalleMaterial;
        }

        // GET: api/ProtocoloDetalleMateriales/5
        [ResponseType(typeof(ProtocoloDetalleMaterial))]
        public IHttpActionResult GetProtocoloDetalleMaterial(int id)
        {
            ProtocoloDetalleMaterial protocoloDetalleMaterial = db.ProtocoloDetalleMaterial.Find(id);
            if (protocoloDetalleMaterial == null)
            {
                return NotFound();
            }

            return Ok(protocoloDetalleMaterial);
        }

        // PUT: api/ProtocoloDetalleMateriales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProtocoloDetalleMaterial(ProtocoloDetalleMaterial protocoloDetalleMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloDetalleMaterial.ultimoUsr == null || protocoloDetalleMaterial.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleMaterial.ultimaFec = DateTime.Now;

            db.Entry(protocoloDetalleMaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocoloDetalleMaterialExists(protocoloDetalleMaterial.IdProtocoloDetMat))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(protocoloDetalleMaterial);
        }

        // POST: api/ProtocoloDetalleMateriales
        [ResponseType(typeof(ProtocoloDetalleMaterial))]
        public IHttpActionResult PostProtocoloDetalleMaterial(ProtocoloDetalleMaterial protocoloDetalleMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (protocoloDetalleMaterial.ultimoUsr == null || protocoloDetalleMaterial.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            protocoloDetalleMaterial.ultimaFec = DateTime.Now;

            db.ProtocoloDetalleMaterial.Add(protocoloDetalleMaterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = protocoloDetalleMaterial.IdProtocoloDetMat }, protocoloDetalleMaterial);
        }

        // DELETE: api/ProtocoloDetalleMateriales/5
        [ResponseType(typeof(ProtocoloDetalleMaterial))]
        public IHttpActionResult DeleteProtocoloDetalleMaterial(int id)
        {
            ProtocoloDetalleMaterial protocoloDetalleMaterial = db.ProtocoloDetalleMaterial.Find(id);
            if (protocoloDetalleMaterial == null)
            {
                return NotFound();
            }

            db.ProtocoloDetalleMaterial.Remove(protocoloDetalleMaterial);
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

        private bool ProtocoloDetalleMaterialExists(int id)
        {
            return db.ProtocoloDetalleMaterial.Count(e => e.IdProtocoloDetMat == id) > 0;
        }
    }
}