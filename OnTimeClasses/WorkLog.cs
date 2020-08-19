using System;

namespace OnTimeClasses
{
    public class WorkLog
    {
        public int WorkLogId { get; set; }
        public DateTime WorkLogDate { get; set; }
        public int FeatureId { get; set; }
        public double WorkDone { get; set; }
        public string Description { get; set; }
        public int? WorkTypeId { get; set; }
    }

    public class WorkReport
    {
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string FeatureName { get; set; }
        public DateTime WorkDate { get; set; }
        public int WorkDay { get; set; }
        public double WorkDone { get; set; }
        public string Description { get; set; }
        public int WorkTypeId { get; set; }
    }
}
