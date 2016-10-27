using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SafetyRecorder.Core;
using SafetyRecorder.Entities;

namespace SafetyRecorder.Web.Controllers
{
    public class SafetyObservationsController : Controller
    {
        private SafetyRecorderDbContext db = new SafetyRecorderDbContext();

        // GET: SafetyObservations
        public ActionResult Index()
        {
            var safetyObservations = db.SafetyObservations.Include(s => s.Observer).Include(s => s.OtherParticipant);
            return View(safetyObservations.ToList());
        }

        // GET: SafetyObservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafetyObservation safetyObservation = db.SafetyObservations.Find(id);
            if (safetyObservation == null)
            {
                return HttpNotFound();
            }
            return View(safetyObservation);
        }

        // GET: SafetyObservations/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Persons, "Id", "Name");
            ViewBag.Id = new SelectList(db.Persons, "Id", "Name");
            return View();
        }

        // POST: SafetyObservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ObserverId,ObservedOn,Location,OtherParticipantId,Subject,ChangedBy,ChangedOn")] SafetyObservation safetyObservation)
        {
            if (ModelState.IsValid)
            {
                db.SafetyObservations.Add(safetyObservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Persons, "Id", "Name", safetyObservation.Id);
            ViewBag.Id = new SelectList(db.Persons, "Id", "Name", safetyObservation.Id);
            return View(safetyObservation);
        }

        // GET: SafetyObservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafetyObservation safetyObservation = db.SafetyObservations.Find(id);
            if (safetyObservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Persons, "Id", "Name", safetyObservation.Id);
            ViewBag.Id = new SelectList(db.Persons, "Id", "Name", safetyObservation.Id);
            return View(safetyObservation);
        }

        // POST: SafetyObservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ObserverId,ObservedOn,Location,OtherParticipantId,Subject,ChangedBy,ChangedOn")] SafetyObservation safetyObservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safetyObservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Persons, "Id", "Name", safetyObservation.Id);
            ViewBag.Id = new SelectList(db.Persons, "Id", "Name", safetyObservation.Id);
            return View(safetyObservation);
        }

        // GET: SafetyObservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafetyObservation safetyObservation = db.SafetyObservations.Find(id);
            if (safetyObservation == null)
            {
                return HttpNotFound();
            }
            return View(safetyObservation);
        }

        // POST: SafetyObservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SafetyObservation safetyObservation = db.SafetyObservations.Find(id);
            db.SafetyObservations.Remove(safetyObservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
