namespace AdminPortal.Models
{
    public class AetherWorkflow : Application
    {
        public string ScheduleId { get; set; }

        public string DateParameterName { get; set; }
        public string DatePattern { get; set; }

        public int RecurrenceId { get; set; }

        public WorkflowRecurrence WorkflowRecurrence { get; set; }
    }
}
