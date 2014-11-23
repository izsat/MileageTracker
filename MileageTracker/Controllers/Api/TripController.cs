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
using MileageTracker.DAL;
using MileageTracker.Models;

namespace MileageTracker.Controllers.Api
{
    public class TripController : ApiController
    {
        private TripDbContext db = new TripDbContext();

        // GET: api/Trip
        public IQueryable<TripModel> GetTrips()
        {
            return db.Trips;
        }

        // GET: api/Trip/5
        /// <summary>
        /// Retrieve trips for specified Employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>List of Trips</returns>
        [ResponseType(typeof(TripModel))]
        public IHttpActionResult GetTripModel(int id)
        {
            List<TripApiModel> tripList = new List<TripApiModel>();

            var trips = from trip in db.Trips
                        where trip.Employee.Id == id
                        select trip;

            if (trips == null)
            {
                return NotFound();
            }

            foreach(var trip in trips)
            {
                TripApiModel newTrip = new TripApiModel();
                newTrip.Id = trip.Id;
                newTrip.StartMileage = trip.StartMileage;
                newTrip.EndMileage = trip.EndMileage;
                newTrip.EmployeeId = trip.Employee.Id;
                newTrip.Purpose = trip.Purpose;
                newTrip.StartLocation = trip.StartLocation;
                newTrip.EndLocation = trip.EndLocation;
                tripList.Add(newTrip);
            }

            IEnumerable<TripApiModel> tripJson = tripList;

            return Ok(tripList);
        }

        // PUT: api/Trip/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTripModel(int id, TripModel tripModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tripModel.Id)
            {
                return BadRequest();
            }

            db.Entry(tripModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripModelExists(id))
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

        // POST: api/Trip
        [ResponseType(typeof(TripModel))]
        public IHttpActionResult PostTripModel(TripModel tripModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trips.Add(tripModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tripModel.Id }, tripModel);
        }

        // DELETE: api/Trip/5
        [ResponseType(typeof(TripModel))]
        public IHttpActionResult DeleteTripModel(int id)
        {
            TripModel tripModel = db.Trips.Find(id);
            if (tripModel == null)
            {
                return NotFound();
            }

            db.Trips.Remove(tripModel);
            db.SaveChanges();

            return Ok(tripModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TripModelExists(int id)
        {
            return db.Trips.Count(e => e.Id == id) > 0;
        }
    }
}