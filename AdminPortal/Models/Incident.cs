namespace AdminPortal.Models
{
    using System;

    public class Incident
    {
        public long IncidentId { get; set; }
        public long AlertId { get; set; }
        public int FaultAppId { get; set; }
        // TODO: add the FaultId later
        public bool IsActive { get; set; }
        public string ServiceInstance { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EmailSubject { get; set; }
        public string Comment { get; set; }
        public bool IsDRIRequired { get; set; }
        public bool IsEmailRequired { get; set; }
        public long? IcmIncidentId { get; set; }
        public string IcmDescription { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public Alert Alert { get; set; }
        public Application Application { get; set; }
    }
}
