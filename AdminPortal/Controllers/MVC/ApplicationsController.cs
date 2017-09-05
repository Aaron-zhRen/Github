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
    public class ApplicationsController : Controller
    {
        private WebPortal db = new WebPortal();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create(FormCollection collection)
        {

            
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
            ViewBag.IcmRoutings = new SelectList(db.IcmRoutings, "IcmRoutingId", "RoutingId",db.IcmRoutings);
            ViewBag.AppGroupId = new SelectList(db.AppGroups, "AppGroupId", "Name");
            ViewBag.AppTypeId = new SelectList(db.AppTypes, "AppTypeId", "Type");
            List<SelectListItem> Recurrencetypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Minutely",Value = "Minutely" },
                new SelectListItem { Text = "Hourly",Value = "Hourly" },
                new SelectListItem { Text = "Daily",Value = "Daily" },
                new SelectListItem { Text = "Weekly",Value = "Weekly" },
                new SelectListItem { Text = "Monthly",Value = "Monthly" }
            };
            List<SelectListItem> OrdinalWords = new List<SelectListItem>
            {
                new SelectListItem { Text = "first",Value = "" },
                new SelectListItem { Text = "second",Value = "" },
                new SelectListItem { Text = "third",Value = "" },
                new SelectListItem { Text = "fourth",Value = "" },
                new SelectListItem { Text = "fifth",Value = "" },
                new SelectListItem { Text = "last",Value = "" },
                new SelectListItem { Text = "every",Value = "" }
            };
            List<SelectListItem> WeeksWords = new List<SelectListItem>
            {
                new SelectListItem { Text = "sunday",Value = "" },
                new SelectListItem { Text = "monday",Value = "" },
                new SelectListItem { Text = "tuesday",Value = "" },
                new SelectListItem { Text = "wednesday",Value = "" },
                new SelectListItem { Text = "thursday",Value = "" },
                new SelectListItem { Text = "firday",Value = "" },
                new SelectListItem { Text = "saturday",Value = "" },
                new SelectListItem { Text = "weekday",Value = "" },
                new SelectListItem { Text = "weekend",Value = "" },
                new SelectListItem { Text = "week",Value = "" }
            };

            ViewBag.RecurrenceTypes = Recurrencetypes;
            ViewBag.OrdinalWords = OrdinalWords;
            ViewBag.WeeksWords = WeeksWords;
            
            return View();

           
        }

      
        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppId,Name,Description,AlertEmails,IsEnabled,IsIcmEnabled,AppTypeId,AppGroupId,TenantId")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(application);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppId,Name,AppTypeId,AppGroupId,TenantId")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
