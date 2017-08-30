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
    public class TenantsController : ApiController
    {
        private AdminManageContext db = new AdminManageContext();

        // GET: api/Tenants
        public IQueryable<Tenant> GetTenants()
        {
            return db.Tenants;
        }

        // GET: api/Tenants/5
        [ResponseType(typeof(Tenant))]
        public async Task<IHttpActionResult> GetTenant(Guid id)
        {
            Tenant tenant = await db.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(tenant);
        }

        // PUT: api/Tenants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTenant(Guid id, Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenant.TenantId)
            {
                return BadRequest();
            }

            db.Entry(tenant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
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

        // POST: api/Tenants
        [ResponseType(typeof(Tenant))]
        public async Task<IHttpActionResult> PostTenant(Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tenants.Add(tenant);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TenantExists(tenant.TenantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tenant.TenantId }, tenant);
        }

        // DELETE: api/Tenants/5
        [ResponseType(typeof(Tenant))]
        public async Task<IHttpActionResult> DeleteTenant(Guid id)
        {
            Tenant tenant = await db.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            await db.SaveChangesAsync();

            return Ok(tenant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(Guid id)
        {
            return db.Tenants.Count(e => e.TenantId == id) > 0;
        }
    }
}