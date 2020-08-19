using System.Collections.Generic;

namespace OnTimeClasses
{
    public class Feature
    {
        public int ProjectId { get; set; }
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<WorkLog> WorkLogs { get; set; }

        public Feature()
        {
            WorkLogs = new List<WorkLog>();
        }
    }
}
