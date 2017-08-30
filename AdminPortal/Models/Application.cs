﻿namespace AdminPortal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class Application
    {
        [Key]
        public int AppId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AlertEmails { get; set; }
        public int? CatchupModeWindow { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsIcmEnabled { get; set; }
        

        public int AppTypeId { get; set; }
        public int AppGroupId { get; set; }
        public int? IcmRoutingId { get; set; }
        public int TenantId { get; set; }

        public AppType AppType { get; set; }
        public AppGroup AppGroup { get; set; }
        public IcmRouting IcmRouting { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<Threshold> Thresholds { get; set; }
        public ICollection<CounterInstance> CounterInstances { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}