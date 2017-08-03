using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class AppGroup
    {
        public int AppGroupId { get; set; }
        [Required]
        public string AppGroupName { get; set; }
        public string AppGroupDescription { get; set; }
    }
}