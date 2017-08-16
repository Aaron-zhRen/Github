namespace AdminPortal.Models { 
    using System;

    public enum RecurrenceFrequency
    {
        Minute,
        Hour,
        Day,
        Week,
        Month,
        MonthRelative
    }

    public class WorkflowRecurrence
    {
        public int RecurrenceId { get; set; }
        public RecurrenceFrequency Frequency { get; set; }
        public int? Internval { get; set; }
        public string Minutes { get; set; }
        public string Hours { get; set; }
        /// <summary>
        /// used only when frequency is MonthRelative
        /// </summary>
        public int? RelativeInterval { get; set; }
        /// <summary>
        /// Used only when Frequency is MonthRelative or Week
        /// </summary>
        public DayOfWeek? DayOfWeek { get; set; }
        /// <summary>
        /// Used only when frequency is month
        /// </summary>
        public int? DayOfMonth { get; set; }
    }
}
