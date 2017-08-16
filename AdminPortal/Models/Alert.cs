namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum AlertStatus
    {
        New,
        ProblingCompleted,
        IncidentCreated,
        EmailSent,
        Closed
    }

    public class Alert
    {
        public long AlertId { get; set; }
        public long CounterInstanceId { get; set; }
        public AlertStatus Status { get; set; }
        public string AlertEmails { get; set; }
        public bool IsDispatched { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public string IcmBody { get; set; }
        public string ServiceInstance { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Comments { get; set; }

        public CounterInstance CounterInstance { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}
