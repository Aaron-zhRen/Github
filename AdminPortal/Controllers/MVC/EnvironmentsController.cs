using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPortal.Models;

namespace AdminPortal.Content.Controllers.MVC
{
    public class EnvironmentsController : Controller
    {
        private WebPortal db = new WebPortal();

        // GET: Environments
        public ActionResult Index(string appsortOrder, string SearchString)
        {
            var environments = db.Environments.OrderByDescending(u => u.Name);
            //function of search
            if (!string.IsNullOrEmpty(SearchString))
            {
                environments = db.Environments.Where(u => u.Name.Contains(SearchString)).OrderByDescending(u => u.Name);
            }
            //function of order
            ViewBag.AppNameSortParm = string.IsNullOrEmpty(appsortOrder) ? "name_desc" : "";
            switch (appsortOrder)
            {
                case "name_desc":
                    environments = environments.OrderByDescending(u => u.Name);
                    break;
                default:
                    environments = environments.OrderBy(u => u.Name);
                    break;
            }
            return View(environments.ToList());
        }

        // GET: Environments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Environment environment = db.Environments.Find(id);
            if (environment == null)
            {
                return HttpNotFound();
            }
            return View(environment);
        }

        // GET: Environments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Environments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "EnvId,Name,Description,IsEnabled")] Models.Environment environment,
            [Bind(Include = "AppId,Name,Description,AlertEmails,IsEnabled,Owners,IsIcmEnabled,AppTypeId,AppGroupId,TenantId,IcmRoutingId")] Application application, 
            string addsome)
        {
            if (!string.IsNullOrEmpty(addsome))
            {
                if (ModelState.IsValid)
                {
                    db.Environments.Add(environment);
                    db.SaveChanges();
                    return RedirectToAction("Create", "Applications");
                }
                
                return View(application);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Environments.Add(environment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(environment);
            }
            
        }

        // GET: Environments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Environment environment = db.Environments.Find(id);
            if (environment == null)
            {
                return HttpNotFound();
            }
            return View(environment);
        }

        // POST: Environments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnvId,Name,Description,IsEnabled")] Models.Environment environment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(environment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(environment);
        }

        // GET: Environments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Environment environment = db.Environments.Find(id);
            if (environment == null)
            {
                return HttpNotFound();
            }
            return View(environment);
        }

        // POST: Environments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Environment environment = db.Environments.Find(id);
            db.Environments.Remove(environment);
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
