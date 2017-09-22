namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Application
    {
        [Key]
        public int AppId { get; set; }
        [StringLength(20, ErrorMessage = "No more than 20 words")]
        [Column("Application Name")]
        [Required]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "No more than 100 words")]
        [Column("Application Description")]
        public string Description { get; set; }
        [Required]
        public string AlertEmails { get; set; }
        public int? CatchupModeWindow { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public bool IsIcmEnabled { get; set; }
        [Required]
        public string Owners { get; set; }
        

        public int? AppTypeId { get; set; }
        [Required]
        public int AppGroupId { get; set; }
        public int? IcmRoutingId { get; set; }
        [Required]
        public string TenantId { get; set; }
       
        public AppType AppType { get; set; }
        public AppGroup AppGroup { get; set; }
        public IcmRouting IcmRouting { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<Threshold> Thresholds { get; set; }
        public ICollection<CounterInstance> CounterInstances { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}
