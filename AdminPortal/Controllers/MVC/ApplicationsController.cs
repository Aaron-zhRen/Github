using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPortal.Models;
using System.Threading.Tasks;
using PagedList;

namespace AdminPortal.Content.Controllers.MVC
{
    public class ApplicationsController : Controller
    {
        private WebPortal db = new WebPortal();

        // GET: Applications
        public ActionResult Index(string appsortOrder,string SearchString, string currentFilter, int? page)
        {

            ViewBag.CurrentSort = appsortOrder;
            var Applications = db.Applications.Include(a => a.AppGroup.Tenant).Include(a => a.AppGroup).Include(a => a.IcmRouting);
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            //function of search
            if (!string.IsNullOrEmpty(SearchString))
            {
                Applications = db.Applications.Where(u => u.Name.Contains(SearchString)).Include(a => a.AppGroup.Tenant).Include(a => a.AppGroup);
            }
            //function of order
            ViewBag.AppNameSortParm = string.IsNullOrEmpty(appsortOrder) ? "name_desc" : "";
            switch (appsortOrder)
            {
                case "name_desc":Applications = Applications.OrderByDescending(u => u.Name);
                    break;
                default:Applications = Applications.OrderBy(u => u.Name);
                    break;
            }

            int pageSize = 16;
            int pageNumber = (page ?? 1);
           
            return View(Applications.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create([Bind(Include = "AppId,Name,Description,AlertEmails,IsEnabled,Owners,IsIcmEnabled,AppTypeId,AppGroupId,TenantId,IcmRoutingId")] Application application,string addsome, string value)
        {
            
            DateforDropownlist();
            if (!string.IsNullOrEmpty(addsome))
            {

                switch (addsome)
                {
                    case "AddTenant": ViewBag.showAddTenantPanel = true; break;
                    case "AddAppgroup": ViewBag.showAddAppgroupPanel = true; break;
                    case "AddIcm": ViewBag.showAddIcmPanel = true; break;
                    case "AddEnvironment": ViewBag.showAddEnvironmentPanel = true; break;
                }

            }
            if (!string.IsNullOrEmpty(value))
            {
                int icmid = int.Parse(value);
                var icm = db.IcmRoutings.Where(a => a.IcmRoutingId.Equals(icmid)).Include(a => a.IcmSubscription).ToList();
                foreach (var item in icm) {
                    ViewBag.SelsectedIcmName = item.IcmName;
                    ViewBag.SelsectedRoutingId = item.RoutingId;
                    ViewBag.SelsectedServiceName = item.IcmSubscription.ServiceName;
                    ViewBag.SelsectedCorrelationId = item.CorrelationId;
                }
            }

            return View();
        }

        //add new env panel
       
       
        //some SelectlistItem resource
        public void DateforDropownlist() {
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
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
            ViewBag.IcmRoutingId = new SelectList(db.IcmRoutings, "IcmRoutingId", "IcmName");
            ViewBag.AppGroupId = new SelectList(db.AppGroups, "AppGroupId", "Name");
            ViewBag.AppTypeId = new SelectList(db.AppTypes, "AppTypeId", "Type");
            ViewBag.EnvId = new SelectList(db.Environments, "EnvId", "Name");
            ViewBag.Connectorid = new SelectList(db.IcmSubscriptions, "ConnectorId", "ConnectorId");


        }
        
      
        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "AppId,Name,Description,AlertEmails,CatchupModeWindow,IsEnabled,IsIcmEnabled,Owners,AppTypeId,AppGroupId,IcmRoutingId,TenantId")] Application application,
            [Bind(Include = "Name,Description,Owners")]Tenant tenant,
            [Bind(Include = "IcmName,IcmRoutingId,IcmSubscriptionId,RoutingId,CorrelationId")] IcmRouting icmRouting, 
            [Bind(Include = "ServiceName,ConnectorId")] IcmSubscription icmSubscription,
            [Bind(Include = "AppGroupId,TenantId,Name,Description")] AppGroup appGroup,
            [Bind(Include = "EnvId,Name,Description,IsEnabled")] Models.Environment environment,string add)
        {
            if (ModelState.IsValid)
            {

                switch (add)
                {
                    case "addTenant":
                        tenant.TenantId = Guid.NewGuid();
                        db.Tenants.Add(tenant);
                        await db.SaveChangesAsync();
                        ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "Name");
                        break;
                    case "addApplication":
                        db.Applications.Add(application);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    case "addIcm":
                        db.IcmSubscriptions.Add(icmSubscription);
                        db.IcmRoutings.Add(icmRouting);
                        await db.SaveChangesAsync();
                        break;
                    case "addEvn":
                        db.Environments.Add(environment);
                        await db.SaveChangesAsync();
                        break;
                    case "addAppgroup":
                        db.AppGroups.Add(appGroup);
                        await db.SaveChangesAsync();
                        break;
                }
            }
           
            DateforDropownlist();
            return View(application);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            DateforDropownlist();
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
