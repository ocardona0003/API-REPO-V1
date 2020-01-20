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
    [RoutePrefix("api/TratadoCoronas")]
    public class TratadoCoronasController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/TratadoCoronas
        public IQueryable<TratadoCorona> GetTratadoCorona()
        {
            return db.TratadoCorona;
        }

        // GET: api/TratadoCoronas/5
        [ResponseType(typeof(TratadoCorona))]
        public IHttpActionResult GetTratadoCorona(string id)
        {
            TratadoCorona tratadoCorona = db.TratadoCorona.Find(id);
            if (tratadoCorona == null)
            {
                return NotFound();
            }

            return Ok(tratadoCorona);
        }

        // PUT: api/TratadoCoronas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTratadoCorona(TratadoCorona tratadoCorona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tratadoCorona.ultimoUsr == null || tratadoCorona.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tratadoCorona.ultimaFec = DateTime.Now;

            db.Entry(tratadoCorona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TratadoCoronaExists(tratadoCorona.idTratadoCorona))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tratadoCorona);
        }

        // POST: api/TratadoCoronas
        [ResponseType(typeof(TratadoCorona))]
        public IHttpActionResult PostTratadoCorona(TratadoCorona tratadoCorona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tratadoCorona.ultimoUsr == null || tratadoCorona.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            tratadoCorona.ultimaFec = DateTime.Now;

            db.TratadoCorona.Add(tratadoCorona);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TratadoCoronaExists(tratadoCorona.idTratadoCorona))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tratadoCorona.idTratadoCorona }, tratadoCorona);
        }

        // DELETE: api/TratadoCoronas/5
        [ResponseType(typeof(TratadoCorona))]
        public IHttpActionResult DeleteTratadoCorona(string id)
        {
            TratadoCorona tratadoCorona = db.TratadoCorona.Find(id);
            if (tratadoCorona == null)
            {
                return NotFound();
            }

            db.TratadoCorona.Remove(tratadoCorona);
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

        private bool TratadoCoronaExists(string id)
        {
            return db.TratadoCorona.Count(e => e.idTratadoCorona == id) > 0;
        }
    }
}