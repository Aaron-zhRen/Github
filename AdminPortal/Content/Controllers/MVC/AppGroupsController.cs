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
    public class AppGroupsController : Controller
    {
        private AppGroupsContext db = new AppGroupsContext();
        private TenantsContext TenantsContextDb = new TenantsContext();

        //Get the Tenants list

        public List<SelectListItem> GetByTenantId(int TenantId)
        {

            var Tenantslist = TenantsContextDb.Tenants;
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (var it in Tenantslist)
            {
                item.Add(new SelectListItem { Text = it.Name, Value = it.TenantId.ToString()});
            }
            item.Insert(0, new SelectListItem { Text = "-会员类型-", Value = "-1" });
            return item;
        }

        public ActionResult TenantNamelist(int id)
        {
            TenantsContext Tenants = new TenantsContext();
            var Tenantslist = Tenants.Tenants;
            TenantNamelist mt = Tenantslist.First();
            ViewData["MemberKind"] = GetByTenantId(4);
            return View(mt);
        }




        // GET: AppGroups
        public async Task<ActionResult> Index()
        {
            var appGroups = db.AppGroups.Include(a => a.Tenant);
            return View(await appGroups.ToListAsync());
        }

        // GET: AppGroups/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppGroup appGroup = await db.AppGroups.FindAsync(id);
            if (appGroup == null)
            {
                return HttpNotFound();
            }
            return View(appGroup);
        }

        // GET: AppGroups/Create
        public ActionResult Create()
        {
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
            return View();
        }

        // POST: AppGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AppGroupId,TenantId,Name,Description")] AppGroup appGroup)
        {
            if (ModelState.IsValid)
            {
                db.AppGroups.Add(appGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", appGroup.TenantId);
            return View(appGroup);
        }

        // GET: AppGroups/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppGroup appGroup = await db.AppGroups.FindAsync(id);
            if (appGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", appGroup.TenantId);
            return View(appGroup);
        }

        // POST: AppGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AppGroupId,TenantId,Name,Description")] AppGroup appGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name", appGroup.TenantId);
            return View(appGroup);
        }

        // GET: AppGroups/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppGroup appGroup = await db.AppGroups.FindAsync(id);
            if (appGroup == null)
            {
                return HttpNotFound();
            }
            return View(appGroup);
        }

        // POST: AppGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AppGroup appGroup = await db.AppGroups.FindAsync(id);
            db.AppGroups.Remove(appGroup);
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
