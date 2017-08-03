using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required]
        public string TenantName { get; set; }
        public string IcmName { get; set; }
       // public int AppGroupId { get; set; }
        public AppGroup AppGroup { get; set; }
    }
}