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
    [RoutePrefix("api/TipoCajas")]
    public class TipoCajasController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TipoCajas
        public IQueryable<TipoCaja> GetTipoCaja()
        {
            return db.TipoCaja;
        }

        // GET: api/TipoCajas/5
        [ResponseType(typeof(TipoCaja))]
        public IHttpActionResult GetTipoCaja(int id)
        {
            TipoCaja tipoCaja = db.TipoCaja.Find(id);
            if (tipoCaja == null)
            {
                return NotFound();
            }

            return Ok(tipoCaja);
        }

        // PUT: api/TipoCajas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoCaja(TipoCaja tipoCaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

   
            if (tipoCaja.ultimoUsr == null || tipoCaja.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoCaja.ultimaFec = DateTime.Now;

            db.Entry(tipoCaja).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCajaExists(tipoCaja.idTipoCaja))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tipoCaja);
        }

        // POST: api/TipoCajas
        [ResponseType(typeof(TipoCaja))]
        public IHttpActionResult PostTipoCaja(TipoCaja tipoCaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoCaja.ultimoUsr == null || tipoCaja.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoCaja.ultimaFec = DateTime.Now;

            db.TipoCaja.Add(tipoCaja);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoCaja.idTipoCaja }, tipoCaja);
        }

        // DELETE: api/TipoCajas/5
        [ResponseType(typeof(TipoCaja))]
        public IHttpActionResult DeleteTipoCaja(int id)
        {
            TipoCaja tipoCaja = db.TipoCaja.Find(id);
            if (tipoCaja == null)
            {
                return NotFound();
            }

            db.TipoCaja.Remove(tipoCaja);
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

        private bool TipoCajaExists(int id)
        {
            return db.TipoCaja.Count(e => e.idTipoCaja == id) > 0;
        }
    }
}