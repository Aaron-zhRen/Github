using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AdminPortal.Models;

namespace AdminPortal.Controllers
{
    public class AppGroupsController : ApiController
    {
        private OnboardServiceContext db = new OnboardServiceContext();

        // GET: api/AppGroups
        public IQueryable<AppGroup> GetAppGroups()
        {
            return db.AppGroups;
        }

        // GET: api/AppGroups/5
        [ResponseType(typeof(AppGroup))]
        public async Task<IHttpActionResult> GetAppGroup(int id)
        {
            AppGroup appGroup = await db.AppGroups.FindAsync(id);
            if (appGroup == null)
            {
                return NotFound();
            }

            return Ok(appGroup);
        }

        // PUT: api/AppGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppGroup(int id, AppGroup appGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appGroup.AppGroupId)
            {
                return BadRequest();
            }

            db.Entry(appGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AppGroups
        [ResponseType(typeof(AppGroup))]
        public async Task<IHttpActionResult> PostAppGroup(AppGroup appGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppGroups.Add(appGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appGroup.AppGroupId }, appGroup);
        }

        // DELETE: api/AppGroups/5
        [ResponseType(typeof(AppGroup))]
        public async Task<IHttpActionResult> DeleteAppGroup(int id)
        {
            AppGroup appGroup = await db.AppGroups.FindAsync(id);
            if (appGroup == null)
            {
                return NotFound();
            }

            db.AppGroups.Remove(appGroup);
            await db.SaveChangesAsync();

            return Ok(appGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppGroupExists(int id)
        {
            return db.AppGroups.Count(e => e.AppGroupId == id) > 0;
        }
    }
}