namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;

    public class Tenant
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owners { get; set; }

        public ICollection<AppGroup> AppGroups { get; set; }
        public ICollection<IcmSubscription> IcmSubscriptions { get; set; }
    }
}
