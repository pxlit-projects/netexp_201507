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
using Business_objects;
using TEST_VERKEERSBORDEN.Models;

namespace TEST_VERKEERSBORDEN.Controllers
{
    public class VerkeersbordsController : ApiController
    {
        private VerkeersbordContext db = new VerkeersbordContext();

        // GET: api/Verkeersbords
        public IQueryable<Verkeersbord> GetVerkeersborden()
        {
            return db.Verkeersborden;
        }

        // GET: api/Verkeersbords/5
        [ResponseType(typeof(Verkeersbord))]
        public IHttpActionResult GetVerkeersbord(int id)
        {
            Verkeersbord verkeersbord = db.Verkeersborden.Find(id);
            if (verkeersbord == null)
            {
                return NotFound();
            }

            return Ok(verkeersbord);
        }

        // PUT: api/Verkeersbords/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVerkeersbord(int id, Verkeersbord verkeersbord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != verkeersbord.id)
            {
                return BadRequest();
            }

            db.Entry(verkeersbord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerkeersbordExists(id))
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

        // POST: api/Verkeersbords
        [ResponseType(typeof(Verkeersbord))]
        public IHttpActionResult PostVerkeersbord(Verkeersbord verkeersbord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Verkeersborden.Add(verkeersbord);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = verkeersbord.id }, verkeersbord);
        }

        // DELETE: api/Verkeersbords/5
        [ResponseType(typeof(Verkeersbord))]
        public IHttpActionResult DeleteVerkeersbord(int id)
        {
            Verkeersbord verkeersbord = db.Verkeersborden.Find(id);
            if (verkeersbord == null)
            {
                return NotFound();
            }

            db.Verkeersborden.Remove(verkeersbord);
            db.SaveChanges();

            return Ok(verkeersbord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VerkeersbordExists(int id)
        {
            return db.Verkeersborden.Count(e => e.id == id) > 0;
        }
    }
}