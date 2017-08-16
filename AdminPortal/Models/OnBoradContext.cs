using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class OnBoradContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OnBoradContext() : base("name=OnBoradContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<OnBoradContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<AdminPortal.Models.OnBorad> OnBorads { get; set; }

        public System.Data.Entity.DbSet<AdminPortal.Models.Counter> Counters { get; set; }

        public System.Data.Entity.DbSet<AdminPortal.Models.IcmRouting> IcmRoutings { get; set; }
    }
}
