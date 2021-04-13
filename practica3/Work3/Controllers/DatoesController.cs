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
using Work3.Models;

namespace Work3.Controllers
{
    public class DatoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Datoes
        [Authorize]
        public IQueryable<Dato> GetDatoes()
        {
            return db.Datoes;
        }

        // GET: api/Datoes/5
        [Authorize]
        [ResponseType(typeof(Dato))]
        public IHttpActionResult GetDato(int id)
        {
            Dato dato = db.Datoes.Find(id);
            if (dato == null)
            {
                return NotFound();
            }

            return Ok(dato);
        }

        // PUT: api/Datoes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDato(int id, Dato dato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dato.PerosnId)
            {
                return BadRequest();
            }

            db.Entry(dato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Datoes
        [Authorize]
        [ResponseType(typeof(Dato))]
        public IHttpActionResult PostDato(Dato dato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Datoes.Add(dato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dato.PerosnId }, dato);
        }

        // DELETE: api/Datoes/5
        [Authorize]
        [ResponseType(typeof(Dato))]
        public IHttpActionResult DeleteDato(int id)
        {
            Dato dato = db.Datoes.Find(id);
            if (dato == null)
            {
                return NotFound();
            }

            db.Datoes.Remove(dato);
            db.SaveChanges();

            return Ok(dato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatoExists(int id)
        {
            return db.Datoes.Count(e => e.PerosnId == id) > 0;
        }
    }
}