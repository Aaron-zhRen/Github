namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.InteropServices;

    public class AppGroup
    {
        public int AppGroupId { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Foreign keys relation ship
        /// </summary>
        public Tenant Tenant { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
