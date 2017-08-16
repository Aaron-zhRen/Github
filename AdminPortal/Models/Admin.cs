using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public int AppGroupId { get; set; }
        public AppGroup AppGroup { get; set; }
        public int AppTypeId { get; set; }
        public AppType AppType { get; set; }
    }
}