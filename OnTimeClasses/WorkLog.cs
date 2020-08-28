using System;

namespace OnTimeClasses
{
    public class WorkLog
    {
        public int WorkLogId { get; set; }
        public DateTime WorkLogDate { get; set; }
        public int FeatureId { get; set; }
        public float WorkDone { get; set; }
        public string Description { get; set; }
        public int? WorkTypeId { get; set; }
    }

}
