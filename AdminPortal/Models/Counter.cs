namespace AdminPortal.Models
{
    using System.Collections.Generic;

    public class Counter
    {
        public int CounterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsIncremental { get; set; }
        public string ThresholdUnit { get; set; }

        public ICollection<Threshold> Thresholds { get; set; }
        public ICollection<CounterInstance> CounterInstances { get; set; }
    }
}
