﻿using System;
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

               
        // GET: AppGroups
        public async Task<ActionResult> Index()
        {
            var appGroups = db.AppGroups;
            //.Include(a => a.Tenant)
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
            ViewBag.TenantId = new SelectList(TenantsContextDb.Tenants, "TenantId", "Name");
            //TenantNamelist();
            return View();
        }

        ////Get the Tenants list for AppGroup to choose
        //public ActionResult TenantNamelist()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    IEnumerable<Tenant> Tenants = TenantsContextDb.Tenants;
        //    foreach (var Tenant in Tenants)
        //    {
        //        items.Add(new SelectListItem { Text = Tenant.TenantId.ToString(), Value = Tenant.TenantId.ToString() });
        //    }
        //    Console.WriteLine(items);
        //    ViewData["TenantsList"] = items;
        //    return View();
        //}



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