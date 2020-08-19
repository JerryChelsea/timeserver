using System;
using System.Collections.Generic;

namespace OnTimeClasses
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int CustomerId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsActive { get; set; }

        public List<Feature> Features { get; set; }

        public Project()
        {
            Features = new List<Feature>();
        }

    }
}
