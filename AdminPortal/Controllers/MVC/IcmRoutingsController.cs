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

namespace AdminPortal.Controllers.MVC
{
    public class IcmRoutingsController : Controller
    {
        private WebPortal db = new WebPortal();

        // GET: IcmRoutings
        public async Task<ActionResult> Index(string appsortOrder, string SearchString)
        {
            var icmRoutings = db.IcmRoutings.Include(i => i.IcmSubscription);
            //function of search
            if (!string.IsNullOrEmpty(SearchString))
            {
                icmRoutings = db.IcmRoutings.Where(u => u.IcmName.Contains(SearchString));
            }
            //function of order
            ViewBag.AppNameSortParm = string.IsNullOrEmpty(appsortOrder) ? "name_desc" : "";
            switch (appsortOrder)
            {
                case "name_desc":
                    icmRoutings = icmRoutings.OrderByDescending(u => u.IcmName);
                    break;
                default:
                    icmRoutings = icmRoutings.OrderBy(u => u.IcmName);
                    break;
            }
            return View(await icmRoutings.ToListAsync());
        }

        // GET: IcmRoutings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmRouting icmRouting = await db.IcmRoutings.FindAsync(id);
            if (icmRouting == null)
            {
                return HttpNotFound();
            }
            return View(icmRouting);
        }

        // GET: IcmRoutings/Create
        public ActionResult Create()
        {
            ViewBag.IcmSubscriptionId = new SelectList(db.IcmSubscriptions, "ServiceName", "ServiceName");
            return View();
        }

        // POST: IcmRoutings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IcmName,IcmRoutingId,IcmSubscriptionId,RoutingId,CorrelationId")] IcmRouting icmRouting)
        {
            if (ModelState.IsValid)
            {
                db.IcmRoutings.Add(icmRouting);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IcmSubscriptionId = new SelectList(db.IcmSubscriptions, "Id", "ServiceName", icmRouting.IcmSubscriptionId);
            return View(icmRouting);
        }

        // GET: IcmRoutings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmRouting icmRouting = await db.IcmRoutings.FindAsync(id);
            if (icmRouting == null)
            {
                return HttpNotFound();
            }
            ViewBag.IcmSubscriptionId = new SelectList(db.IcmSubscriptions, "Id", "ServiceName", icmRouting.IcmSubscriptionId);
            ViewBag.IcmName = new SelectList(db.IcmRoutings, "IcmName", "IcmName", icmRouting.IcmSubscriptionId);
            //Is used by Application?
            List<Application> applications = new List<Application>(db.Applications);
            List<string> ReferedApplications = new List<string>();
            foreach (var item in applications) {
                if (item.IcmRoutingId == id)
                {
                    ReferedApplications.Add(item.Name);
                }
            }

            if (ReferedApplications.Count() != 0)
            {
                ViewBag.ReferedApplications = ReferedApplications;
                return View();
            }
            else {
                ViewBag.IcmSubscriptionId = new SelectList(db.IcmSubscriptions, "Id", "ServiceName", icmRouting.IcmSubscriptionId);
                return View(icmRouting);
            }
            
        }

        // POST: IcmRoutings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IcmRoutingId,IcmSubscriptionId,RoutingId,CorrelationId")] IcmRouting icmRouting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icmRouting).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IcmSubscriptionId = new SelectList(db.IcmSubscriptions, "Id", "ServiceName", icmRouting.IcmSubscriptionId);
            return View(icmRouting);
        }

        // GET: IcmRoutings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmRouting icmRouting = await db.IcmRoutings.FindAsync(id);
            if (icmRouting == null)
            {
                return HttpNotFound();
            }
            return View(icmRouting);
        }

        // POST: IcmRoutings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IcmRouting icmRouting = await db.IcmRoutings.FindAsync(id);
            db.IcmRoutings.Remove(icmRouting);
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
