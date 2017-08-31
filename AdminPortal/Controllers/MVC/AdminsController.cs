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
    public class AdminsController : Controller
    {
        private WebPortal db = new WebPortal();

        // GET: Admins
        public async Task<ActionResult> Index()
        {
            var admins = db.Admins.Include(o => o.Tenant).Include(o => o.AppGroup).Include(O => O.AppType);
            return View(await admins.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            ViewBag.AppGroupId = new SelectList(db.AppGroups, "AppGroupId", "Name");
            ViewBag.AppTypeId = new SelectList(db.AppTypes, "AppTypeId", "Type");
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AdminId,TenantId,AppGroupId,AppTypeId")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AppGroupId = new SelectList(db.AppGroups, "AppGroupId", "Name", admin.AppGroupId);
            ViewBag.AppTypeId = new SelectList(db.AppTypes, "AppTypeId", "Type", admin.AppTypeId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", admin.TenantId);
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppGroupId = new SelectList(db.AppGroups, "AppGroupId", "Name", admin.AppGroupId);
            ViewBag.AppTypeId = new SelectList(db.AppTypes, "AppTypeId", "Type", admin.AppTypeId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", admin.TenantId);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AdminId,TenantId,AppGroupId,AppTypeId")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AppGroupId = new SelectList(db.AppGroups, "AppGroupId", "Name", admin.AppGroupId);
            ViewBag.AppTypeId = new SelectList(db.AppTypes, "AppTypeId", "Type", admin.AppTypeId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", admin.TenantId);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Admin admin = await db.Admins.FindAsync(id);
            db.Admins.Remove(admin);
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
