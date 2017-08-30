using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPortal.Models;

namespace AdminPortal.Content.Controllers
{
    public class OnBoradsController : Controller
    {
        private OnBoradContext db = new OnBoradContext();

        // GET: OnBorads
        public async Task<ActionResult> Index()
        {
            var onBorads = db.OnBorads.Include(o => o.Counter).Include(o => o.IcmRouting);
            return View(await onBorads.ToListAsync());
        }

        // GET: OnBorads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnBorad onBorad = await db.OnBorads.FindAsync(id);
            if (onBorad == null)
            {
                return HttpNotFound();
            }
            return View(onBorad);
        }

        // GET: OnBorads/Create
        public ActionResult Create()
        {
            ViewBag.CounterId = new SelectList(db.Counters, "CounterId", "Name");
            ViewBag.IcmRoutingId = new SelectList(db.IcmRoutings, "IcmRoutingId", "RoutingId");
            return View();
        }

        // POST: OnBorads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ApplicationId,IcmRoutingId,EnvrionmentId,CounterId,RecurrenceId,WeakReference")] OnBorad onBorad)
        {
            if (ModelState.IsValid)
            {
                db.OnBorads.Add(onBorad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CounterId = new SelectList(db.Counters, "CounterId", "Name", onBorad.CounterId);
            ViewBag.IcmRoutingId = new SelectList(db.IcmRoutings, "IcmRoutingId", "RoutingId", onBorad.IcmRoutingId);
            return View(onBorad);
        }

        // GET: OnBorads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnBorad onBorad = await db.OnBorads.FindAsync(id);
            if (onBorad == null)
            {
                return HttpNotFound();
            }
            ViewBag.CounterId = new SelectList(db.Counters, "CounterId", "Name", onBorad.CounterId);
            ViewBag.IcmRoutingId = new SelectList(db.IcmRoutings, "IcmRoutingId", "RoutingId", onBorad.IcmRoutingId);
            return View(onBorad);
        }

        // POST: OnBorads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ApplicationId,IcmRoutingId,EnvrionmentId,CounterId,RecurrenceId,WeakReference")] OnBorad onBorad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onBorad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CounterId = new SelectList(db.Counters, "CounterId", "Name", onBorad.CounterId);
            ViewBag.IcmRoutingId = new SelectList(db.IcmRoutings, "IcmRoutingId", "RoutingId", onBorad.IcmRoutingId);
            return View(onBorad);
        }

        // GET: OnBorads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnBorad onBorad = await db.OnBorads.FindAsync(id);
            if (onBorad == null)
            {
                return HttpNotFound();
            }
            return View(onBorad);
        }

        // POST: OnBorads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OnBorad onBorad = await db.OnBorads.FindAsync(id);
            db.OnBorads.Remove(onBorad);
            await db.SaveChangesAsync();
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
