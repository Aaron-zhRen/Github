namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tenant
    {
       
        public Guid TenantId { get; set; }
        [StringLength(20,ErrorMessage ="No more than 20 words")]
        [Column("Tenant Name")]
        [Required]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "No more than 100 words")]
        [Column("Tenant Description")]
        public string Description { get; set; }
        [StringLength(20, ErrorMessage = "No more than 100 words")]
        [Required]
        public string Owners { get; set; }
        public ICollection<AppGroup> AppGroups { get; set; }
        public ICollection<IcmSubscription> IcmSubscriptions { get; set; }
    }
}
