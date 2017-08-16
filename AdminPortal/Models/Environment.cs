namespace AdminPortal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Environment
    {
        public Environment()
        {
            this.IsEnabled = true;
        }
        [Key]
        public int EnvId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<Threshold> Thresholds { get; set; }
        public ICollection<CounterInstance> CounterInstances { get; set; }
    }
}
