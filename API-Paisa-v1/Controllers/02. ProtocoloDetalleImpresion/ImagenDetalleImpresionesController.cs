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
    [RoutePrefix("api/ImagenDetalleImpresiones")]
    public class ImagenDetalleImpresionesController : ApiController
    {
        private paisaEntities db = new paisaEntities();

        // GET: api/ImagenDetalleImpresiones
        public IQueryable<ImagenDetalleImpresion> GetImagenDetalleImpresion()
        {
            return db.ImagenDetalleImpresion;
        }

        // GET: api/ImagenDetalleImpresiones/5
        [ResponseType(typeof(ImagenDetalleImpresion))]
        public IHttpActionResult GetImagenDetalleImpresion(int id)
        {
            ImagenDetalleImpresion imagenDetalleImpresion = db.ImagenDetalleImpresion.Find(id);
            if (imagenDetalleImpresion == null)
            {
                return NotFound();
            }

            return Ok(imagenDetalleImpresion);
        }

        // PUT: api/ImagenDetalleImpresiones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImagenDetalleImpresion(ImagenDetalleImpresion imagenDetalleImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (imagenDetalleImpresion.ultimoUsr == null || imagenDetalleImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            imagenDetalleImpresion.ultimaFec = DateTime.Now;

            db.Entry(imagenDetalleImpresion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenDetalleImpresionExists(imagenDetalleImpresion.idImagenDetImpresion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(imagenDetalleImpresion);
        }

        // POST: api/ImagenDetalleImpresiones
        [ResponseType(typeof(ImagenDetalleImpresion))]
        public IHttpActionResult PostImagenDetalleImpresion(ImagenDetalleImpresion imagenDetalleImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (imagenDetalleImpresion.ultimoUsr == null || imagenDetalleImpresion.ultimoUsr == 0)
            {
                return BadRequest("no hay usuario para guardar");
            }
            imagenDetalleImpresion.ultimaFec = DateTime.Now;

            db.ImagenDetalleImpresion.Add(imagenDetalleImpresion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imagenDetalleImpresion.idImagenDetImpresion }, imagenDetalleImpresion);
        }

        // DELETE: api/ImagenDetalleImpresiones/5
        [ResponseType(typeof(ImagenDetalleImpresion))]
        public IHttpActionResult DeleteImagenDetalleImpresion(int id)
        {
            ImagenDetalleImpresion imagenDetalleImpresion = db.ImagenDetalleImpresion.Find(id);
            if (imagenDetalleImpresion == null)
            {
                return NotFound();
            }

            db.ImagenDetalleImpresion.Remove(imagenDetalleImpresion);
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

        private bool ImagenDetalleImpresionExists(int id)
        {
            return db.ImagenDetalleImpresion.Count(e => e.idImagenDetImpresion == id) > 0;
        }
    }
}