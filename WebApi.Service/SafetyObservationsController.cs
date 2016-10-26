using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SafetyRecorder.Core;
using SafetyRecorder.Entities;
using System.Collections.Generic;

namespace WebApi.Service.Controllers
{
    public class SafetyObservationsController : ApiController
    {
        private readonly SafetyRecorderDbContext db = new SafetyRecorderDbContext();

        // GET: api/SafetyObservation
        public IEnumerable<SafetyObservation> Get()
        {
            IQueryable<SafetyObservation> safetyObservations = 
                db.SafetyObservations
                    .OrderByDescending(o => o.ObserveredOn);

            return safetyObservations.ToList().AsEnumerable<SafetyObservation>();
        }

        // GET: api/SafetyObservation/{id}
        public IHttpActionResult Get(int id)
        {
            SafetyObservation safetyObservation = db.SafetyObservations.Find(id);

            if (safetyObservation == null)
            {
                return NotFound();
            }

            return Ok(safetyObservation);
        }

        // PUT: api/SafetyObservation
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SafetyObservation safetyObservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != safetyObservation.Id)
            {
                return BadRequest();
            }

            db.Entry(safetyObservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SafetyObservationExists(id))
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

        // POST: api/SafetyObservation
        [ResponseType(typeof(SafetyObservation))]
        public IHttpActionResult Post(SafetyObservation safetyObservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SafetyObservations.Add(safetyObservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = safetyObservation.Id }, safetyObservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SafetyObservationExists(int id)
        {
            return db.SafetyObservations.Count(e => e.Id == id) > 0;
        }
    }

}
