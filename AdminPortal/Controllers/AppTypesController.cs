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

namespace AdminPortal.Content.Controllers
{
    public class AppTypesController : ApiController
    {
        private AdminManageContext db = new AdminManageContext();

        // GET: api/AppTypes
        public IQueryable<AppType> GetAppTypes()
        {
            return db.AppTypes;
        }

        // GET: api/AppTypes/5
        [ResponseType(typeof(AppType))]
        public async Task<IHttpActionResult> GetAppType(int id)
        {
            AppType appType = await db.AppTypes.FindAsync(id);
            if (appType == null)
            {
                return NotFound();
            }

            return Ok(appType);
        }

        // PUT: api/AppTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppType(int id, AppType appType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appType.AppTypeId)
            {
                return BadRequest();
            }

            db.Entry(appType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppTypeExists(id))
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

        // POST: api/AppTypes
        [ResponseType(typeof(AppType))]
        public async Task<IHttpActionResult> PostAppType(AppType appType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppTypes.Add(appType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appType.AppTypeId }, appType);
        }

        // DELETE: api/AppTypes/5
        [ResponseType(typeof(AppType))]
        public async Task<IHttpActionResult> DeleteAppType(int id)
        {
            AppType appType = await db.AppTypes.FindAsync(id);
            if (appType == null)
            {
                return NotFound();
            }

            db.AppTypes.Remove(appType);
            await db.SaveChangesAsync();

            return Ok(appType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppTypeExists(int id)
        {
            return db.AppTypes.Count(e => e.AppTypeId == id) > 0;
        }
    }
}