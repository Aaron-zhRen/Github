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
    public class TenantsController : Controller
    {
        private WebPortal db = new WebPortal();

        // GET: Tenants
        public async Task<ActionResult> Index()
        {
            return View(await db.Tenants.ToListAsync());
        }

        // GET: Tenants/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = await db.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // GET: Tenants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TenantId,Name,Description,Owners")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                tenant.TenantId = Guid.NewGuid();
                db.Tenants.Add(tenant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tenant);
        }

        // GET: Tenants/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = await db.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TenantId,Name,Description,Owners")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = await db.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Tenant tenant = await db.Tenants.FindAsync(id);
            db.Tenants.Remove(tenant);
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
