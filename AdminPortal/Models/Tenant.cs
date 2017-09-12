namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tenant
    {
       
        public Guid TenantId { get; set; }
        [StringLength(10,ErrorMessage ="No more than 10 words")]
        
        public string Name { get; set; }
        [StringLength(20, ErrorMessage = "No more than 20 words")]
        public string Description { get; set; }
        [StringLength(10, ErrorMessage = "No more than 10 words")]
        public string Owners { get; set; }
        public ICollection<AppGroup> AppGroups { get; set; }
        public ICollection<IcmSubscription> IcmSubscriptions { get; set; }
    }
}
