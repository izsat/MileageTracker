﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MileageTracker.DAL;
using MileageTracker.Models;

namespace MileageTracker.Controllers
{
    public class TripController : Controller
    {
        private TripDbContext db = new TripDbContext();

        // GET: TripModels
        public ActionResult Index()
        {
            return View(db.Trips.ToList());
        }

        // GET: TripModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripModel tripModel = db.Trips.Find(id);
            if (tripModel == null)
            {
                return HttpNotFound();
            }
            return View(tripModel);
        }

        // GET: TripModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartMileage,EndMileage,StartTime,EndTime,Purpose")] TripModel tripModel)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(tripModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tripModel);
        }

        // GET: TripModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripModel tripModel = db.Trips.Find(id);
            if (tripModel == null)
            {
                return HttpNotFound();
            }
            return View(tripModel);
        }

        // POST: TripModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartMileage,EndMileage,StartTime,EndTime,Purpose")] TripModel tripModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tripModel);
        }

        // GET: TripModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripModel tripModel = db.Trips.Find(id);
            if (tripModel == null)
            {
                return HttpNotFound();
            }
            return View(tripModel);
        }

        // POST: TripModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TripModel tripModel = db.Trips.Find(id);
            db.Trips.Remove(tripModel);
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
