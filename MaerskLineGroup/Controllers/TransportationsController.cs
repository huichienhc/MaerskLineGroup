using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskLineGroup.Models;

namespace MaerskLineGroup.Controllers
{
    [Authorize]
    public class TransportationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transportations
        public ActionResult Index()
        {
            var transportations = db.Transportations.Include(t => t.Container).Include(t => t.Ship).Include(t => t.Shipyard).Include(t => t.Shipyard1);
            return View(transportations.ToList());
        }

        // GET: Transportations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportation transportation = db.Transportations.Find(id);
            if (transportation == null)
            {
                return HttpNotFound();
            }
            return View(transportation);
        }

        // GET: Transportations/Create
        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName");
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName");
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName");
            return View();
        }

        // POST: Transportations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "TransportationID,ShipID,ContainerID,ArrivalTime,DepartureTime,Price,ArrivalShipyardID,DepartureShipyardID")] Transportation transportation)
        {
            if (ModelState.IsValid)
            {
                db.Transportations.Add(transportation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", transportation.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", transportation.ShipID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", transportation.ArrivalShipyardID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", transportation.DepartureShipyardID);
            return View(transportation);
        }

        // GET: Transportations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportation transportation = db.Transportations.Find(id);
            if (transportation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", transportation.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", transportation.ShipID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", transportation.ArrivalShipyardID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", transportation.DepartureShipyardID);
            return View(transportation);
        }

        // POST: Transportations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "TransportationID,ShipID,ContainerID,ArrivalTime,DepartureTime,Price,ArrivalShipyardID,DepartureShipyardID")] Transportation transportation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", transportation.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", transportation.ShipID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", transportation.ArrivalShipyardID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", transportation.DepartureShipyardID);
            return View(transportation);
        }

        // GET: Transportations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportation transportation = db.Transportations.Find(id);
            if (transportation == null)
            {
                return HttpNotFound();
            }
            return View(transportation);
        }

        // POST: Transportations/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Transportation transportation = db.Transportations.Find(id);
            db.Transportations.Remove(transportation);
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
