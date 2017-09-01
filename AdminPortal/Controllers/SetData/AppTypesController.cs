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

namespace AdminPortal.Controllers.SetData
{
    public class AppTypesController : Controller
    {
        private WebPortal db = new WebPortal();

        // GET: AppTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.AppTypes.ToListAsync());
        }

        // GET: AppTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppType appType = await db.AppTypes.FindAsync(id);
            if (appType == null)
            {
                return HttpNotFound();
            }
            return View(appType);
        }

        // GET: AppTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AppTypeId,Type,Description,IsEnabled")] AppType appType)
        {
            if (ModelState.IsValid)
            {
                db.AppTypes.Add(appType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(appType);
        }

        // GET: AppTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppType appType = await db.AppTypes.FindAsync(id);
            if (appType == null)
            {
                return HttpNotFound();
            }
            return View(appType);
        }

        // POST: AppTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AppTypeId,Type,Description,IsEnabled")] AppType appType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(appType);
        }

        // GET: AppTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppType appType = await db.AppTypes.FindAsync(id);
            if (appType == null)
            {
                return HttpNotFound();
            }
            return View(appType);
        }

        // POST: AppTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AppType appType = await db.AppTypes.FindAsync(id);
            db.AppTypes.Remove(appType);
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
