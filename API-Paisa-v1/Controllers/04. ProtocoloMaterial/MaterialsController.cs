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
    [RoutePrefix("api/Materials")]
    public class MaterialsController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/Materials
        public IQueryable<Material> GetMaterial()
        {
            return db.Material;
        }

        // GET: api/Materials/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult GetMaterial(string id)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        // PUT: api/Materials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (material.ultimoUsr == null || material.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            material.ultimaFec = DateTime.Now;

            db.Entry(material).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(material.idMaterial))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(material);
        }

        // POST: api/Materials
        [ResponseType(typeof(Material))]
        public IHttpActionResult PostMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (material.ultimoUsr == null || material.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            material.ultimaFec = DateTime.Now;

            db.Material.Add(material);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MaterialExists(material.idMaterial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = material.idMaterial }, material);
        }

        // DELETE: api/Materials/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult DeleteMaterial(string id)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            db.Material.Remove(material);
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

        private bool MaterialExists(string id)
        {
            return db.Material.Count(e => e.idMaterial == id) > 0;
        }
    }
}