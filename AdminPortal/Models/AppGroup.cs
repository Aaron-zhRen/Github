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
        [Required]
        public Guid TenantId { get; set; }
        [StringLength(20, ErrorMessage = "No more than 20 words")]
        [Column("AppGroup Name")]
        [Required]
        public string Name { get; set; }
        [StringLength(100,ErrorMessage ="No more than 100 words")]
        [Column("AppGroup Description")]
        public string Description { get; set; }
        /// <summary>
        /// Foreign keys relation ship
        /// </summary>
        public Tenant Tenant { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
