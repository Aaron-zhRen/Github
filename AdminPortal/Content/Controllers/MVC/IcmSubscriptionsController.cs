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

namespace AdminPortal.Content.Controllers.MVC
{
    public class IcmSubscriptionsController : Controller
    {
        private IcmsContext db = new IcmsContext();

        // GET: IcmSubscriptions
        public async Task<ActionResult> Index()
        {
            var icmSubscriptions = db.IcmSubscriptions.Include(i => i.Tenant);
            return View(await icmSubscriptions.ToListAsync());
        }

        // GET: IcmSubscriptions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmSubscription icmSubscription = await db.IcmSubscriptions.FindAsync(id);
            if (icmSubscription == null)
            {
                return HttpNotFound();
            }
            return View(icmSubscription);
        }

        // GET: IcmSubscriptions/Create
        public ActionResult Create()
        {
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
            return View();
        }

        // POST: IcmSubscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TenantId,ServiceName,ConnectorId")] IcmSubscription icmSubscription)
        {
            if (ModelState.IsValid)
            {
                db.IcmSubscriptions.Add(icmSubscription);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", icmSubscription.TenantId);
            return View(icmSubscription);
        }

        // GET: IcmSubscriptions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmSubscription icmSubscription = await db.IcmSubscriptions.FindAsync(id);
            if (icmSubscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", icmSubscription.TenantId);
            return View(icmSubscription);
        }

        // POST: IcmSubscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TenantId,ServiceName,ConnectorId")] IcmSubscription icmSubscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icmSubscription).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", icmSubscription.TenantId);
            return View(icmSubscription);
        }

        // GET: IcmSubscriptions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmSubscription icmSubscription = await db.IcmSubscriptions.FindAsync(id);
            if (icmSubscription == null)
            {
                return HttpNotFound();
            }
            return View(icmSubscription);
        }

        // POST: IcmSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IcmSubscription icmSubscription = await db.IcmSubscriptions.FindAsync(id);
            db.IcmSubscriptions.Remove(icmSubscription);
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
