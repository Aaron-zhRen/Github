using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class OnBorad
    {
        [Key]
        public int ApplicationId { get; set; }
        public int IcmRoutingId { get; set; }
        public int EnvrionmentId { get; set; }
        public int CounterId { get; set; }
        //public int RecurrenceId { get; set; }

        public Application Application { get; set; }
        public IcmRouting IcmRouting { get; set; }
        public Environment Environment { get; set; }
        public Counter Counter { get; set; }
        //public WorkflowRecurrence WorkflowRecurrence { get; set; }

    }
}