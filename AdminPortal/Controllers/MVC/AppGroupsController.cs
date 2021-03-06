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
using PagedList;

namespace AdminPortal.Content.Controllers.MVC
{
    public class AppGroupsController : Controller
    {
        private WebPortal db = new WebPortal();
        
        // GET: AppGroups
        public async Task<ActionResult> Index(string appsortOrder, string SearchString,string currentFilter,int? page)
        {
            ViewBag.CurrentSort = appsortOrder;
            var appGroups = db.AppGroups.Include(a => a.Tenant);

            if (SearchString != null)
            {
                page = 1;
            }
            else {
                SearchString = currentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            //function of search
            if (!string.IsNullOrEmpty(SearchString))
            {
                appGroups = db.AppGroups.Where(u => u.Name.Contains(SearchString));
            }
            //function of order
            ViewBag.AppNameSortParm = string.IsNullOrEmpty(appsortOrder) ? "name_desc" : "";
            switch (appsortOrder)
            {
                case "name_desc":
                    appGroups = appGroups.OrderByDescending(u => u.Name);
                    break;
                default:
                    appGroups = appGroups.OrderBy(u => u.Name);
                    break;
            }
            int pageSize = 16;
            int pageNumber = (page ?? 1);

            // return View(await appGroups.ToListAsync());
            return View(appGroups.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create(string AddTenant)
        {
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");

            if (!string.IsNullOrEmpty(AddTenant)) {

                ViewBag.showAddTenantPanel = true;
            }
            
            return View();
        }
       
        // POST: AppGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AppGroupId,TenantId,Name,Description")] AppGroup appGroup, [Bind(Include = "Name,Description,Owners")]Tenant tenant, string add)
        {

            switch (add)
            {
                case "addTenant":
                    tenant.TenantId = Guid.NewGuid();
                    
                        db.Tenants.Add(tenant);
                        await db.SaveChangesAsync();
                    
                    ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
                    break;
                case "addAppgroup":
                    
                        db.AppGroups.Add(appGroup);
                        await db.SaveChangesAsync();
                    
                        return RedirectToAction("Index");

            }

            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
            return View();
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
