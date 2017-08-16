namespace AdminPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CounterInstance
    {
        public long CounterInstanceId { get; set; }
        public int AppId { get; set; }
        public int CounterId { get; set; }
        public int EnvId { get; set; }

        public DateTime Delta { get; set; }
        public string AppInstanceId { get; set; }
        public DateTime Timestamp { get; set; }
        public long CounterValue { get; set; }
        public string Machine { get; set; }
        public string ServiceInstance { get; set; }
        public string Annotation { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public Application Application { get; set; }
        public Counter Counter { get; set; }
        public Environment Environment { get; set; }

        public ICollection<Alert> Alerts { get; set; }
    }
}
