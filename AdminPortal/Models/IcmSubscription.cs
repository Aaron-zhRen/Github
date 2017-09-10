namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;

    public class IcmSubscription
    {
        public int Id { get; set; }
        public Guid? TenantId { get; set; }
        public string ServiceName { get; set; }
        public Guid ConnectorId { get; set; }

        public Tenant Tenant { get; set; }
        public ICollection<IcmRouting> IcmRoutings { get; set; }
    }
}
