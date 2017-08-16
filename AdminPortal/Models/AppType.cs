namespace AdminPortal.Models
{
    using System.Collections.Generic;

    public class AppType
    {
        public AppType()
        {
            this.IsEnabled = true;
        }

        public int AppTypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}
