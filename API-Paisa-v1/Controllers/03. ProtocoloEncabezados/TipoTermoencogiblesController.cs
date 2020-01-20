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
    [RoutePrefix("api/TipoTermoencogibles")]
    public class TipoTermoencogiblesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TipoTermoencogibles
        public IQueryable<TipoTermoencogible> GetTipoTermoencogible()
        {
            return db.TipoTermoencogible;
        }

        // GET: api/TipoTermoencogibles/5
        [ResponseType(typeof(TipoTermoencogible))]
        public IHttpActionResult GetTipoTermoencogible(int id)
        {
            TipoTermoencogible tipoTermoencogible = db.TipoTermoencogible.Find(id);
            if (tipoTermoencogible == null)
            {
                return NotFound();
            }

            return Ok(tipoTermoencogible);
        }

        // PUT: api/TipoTermoencogibles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoTermoencogible(TipoTermoencogible tipoTermoencogible)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoTermoencogible.ultimoUsr == null || tipoTermoencogible.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoTermoencogible.ultimaFec = DateTime.Now;

            db.Entry(tipoTermoencogible).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTermoencogibleExists(tipoTermoencogible.idTipoTermoE))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tipoTermoencogible);
        }

        // POST: api/TipoTermoencogibles
        [ResponseType(typeof(TipoTermoencogible))]
        public IHttpActionResult PostTipoTermoencogible(TipoTermoencogible tipoTermoencogible)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoTermoencogible.ultimoUsr == null || tipoTermoencogible.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tipoTermoencogible.ultimaFec = DateTime.Now;

            db.TipoTermoencogible.Add(tipoTermoencogible);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TipoTermoencogibleExists(tipoTermoencogible.idTipoTermoE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipoTermoencogible.idTipoTermoE }, tipoTermoencogible);
        }

        // DELETE: api/TipoTermoencogibles/5
        [ResponseType(typeof(TipoTermoencogible))]
        public IHttpActionResult DeleteTipoTermoencogible(int id)
        {
            TipoTermoencogible tipoTermoencogible = db.TipoTermoencogible.Find(id);
            if (tipoTermoencogible == null)
            {
                return NotFound();
            }

            db.TipoTermoencogible.Remove(tipoTermoencogible);
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

        private bool TipoTermoencogibleExists(int id)
        {
            return db.TipoTermoencogible.Count(e => e.idTipoTermoE == id) > 0;
        }
    }
}