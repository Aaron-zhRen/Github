namespace AdminPortal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Environment
    {
        public Environment()
        {
            this.IsEnabled = true;
        }
        [Key]
        public int EnvId { get; set; }
        [Column("Environment Name")]
        public string Name { get; set; }
        [Column("Environment Description")]
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<Threshold> Thresholds { get; set; }
        public ICollection<CounterInstance> CounterInstances { get; set; }
    }
}
