namespace AdminPortal.Models
{
    public class Threshold
    {
        public int ThresholdId { get; set; }
        public int AppId { get; set; }
        public int CounterId { get; set; }
        public int EnvId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsIcmEnabled { get; set; }
        public long Value { get; set; }
        public string Operation { get; set; }
        public int Severity { get; set; }
        public int Priority { get; set; }

        public Application Application { get; set; }
        public Counter Counter { get; set; }
        public Environment Environment { get; set; }
    }
}
