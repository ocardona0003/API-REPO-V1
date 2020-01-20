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
    [Authorize]
    [RoutePrefix("api/RodilloImpresiones")]
    public class RodilloImpresionesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/RodilloImpresiones
        public IQueryable<RodilloImpresion> GetRodilloImpresion()
        {
            return db.RodilloImpresion;
        }

        // GET: api/RodilloImpresiones/5
        [ResponseType(typeof(RodilloImpresion))]
        public IHttpActionResult GetRodilloImpresion(int id)
        {
            RodilloImpresion rodilloImpresion = db.RodilloImpresion.Find(id);
            if (rodilloImpresion == null)
            {
                return NotFound();
            }

            return Ok(rodilloImpresion);
        }

        // PUT: api/RodilloImpresiones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRodilloImpresion(RodilloImpresion rodilloImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (rodilloImpresion.ultimoUsr == null || rodilloImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            rodilloImpresion.ultimaFec = DateTime.Now;
            db.Entry(rodilloImpresion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RodilloImpresionExists(rodilloImpresion.idRodilloImpresion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(rodilloImpresion);
        }

        // POST: api/RodilloImpresiones
        [ResponseType(typeof(RodilloImpresion))]
        public IHttpActionResult PostRodilloImpresion(RodilloImpresion rodilloImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (rodilloImpresion.ultimoUsr == null || rodilloImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }

            rodilloImpresion.ultimaFec = DateTime.Now;
            db.RodilloImpresion.Add(rodilloImpresion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rodilloImpresion.idRodilloImpresion }, rodilloImpresion);
        }

        // DELETE: api/RodilloImpresiones/5
        [ResponseType(typeof(RodilloImpresion))]
        public IHttpActionResult DeleteRodilloImpresion(int id)
        {
            RodilloImpresion rodilloImpresion = db.RodilloImpresion.Find(id);
            if (rodilloImpresion == null)
            {
                return NotFound();
            }
 
            db.RodilloImpresion.Remove(rodilloImpresion);
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

        private bool RodilloImpresionExists(int id)
        {
            return db.RodilloImpresion.Count(e => e.idRodilloImpresion == id) > 0;
        }
    }
}