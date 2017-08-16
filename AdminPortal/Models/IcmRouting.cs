namespace AdminPortal.Models
{
    using System.Collections.Generic;

    public class IcmRouting
    {
        public int IcmRoutingId { get; set; }
        public int IcmSubscriptionId { get; set; }
        public string RoutingId { get; set; }
        public string CorrelationId { get; set; }

        public IcmSubscription IcmSubscription { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
