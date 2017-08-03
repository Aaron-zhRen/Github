using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class OnboardServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OnboardServiceContext() : base("name=OnboardServiceContext")
        {
        }

        public System.Data.Entity.DbSet<AdminPortal.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<AdminPortal.Models.AppGroup> AppGroups { get; set; }
    }
}
