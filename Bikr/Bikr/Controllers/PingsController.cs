using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bikr.Models;

namespace Bikr.Controllers
{
    public class PingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pings
        public ActionResult Index()
        {
            return View(db.Pings.ToList());
        }

        // GET: Pings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ping ping = db.Pings.Find(id);
            if (ping == null)
            {
                return HttpNotFound();
            }
            return View(ping);
        }

        // GET: Pings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PingID,BikeFindrID,PingDateTime,PingX,PingY")] Ping ping)
        {
            if (ModelState.IsValid)
            {
                db.Pings.Add(ping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ping);
        }

        // GET: Pings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ping ping = db.Pings.Find(id);
            if (ping == null)
            {
                return HttpNotFound();
            }
            return View(ping);
        }

        // POST: Pings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PingID,BikeFindrID,PingDateTime,PingX,PingY")] Ping ping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ping);
        }

        // GET: Pings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ping ping = db.Pings.Find(id);
            if (ping == null)
            {
                return HttpNotFound();
            }
            return View(ping);
        }

        // POST: Pings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ping ping = db.Pings.Find(id);
            db.Pings.Remove(ping);
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
