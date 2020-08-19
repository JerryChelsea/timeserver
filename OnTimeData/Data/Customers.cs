using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [Required]
        [Column("CompanyURL")]
        [StringLength(500)]
        public string CompanyUrl { get; set; }
        public int? DefectViewProjectId { get; set; }
        public int? DefectViewFilterId { get; set; }
        public int? DefectAddEditProjectId { get; set; }
        public int? FeatureViewProjectId { get; set; }
        public int? FeatureViewFilterId { get; set; }
        public int? FeatureAddEditProjectId { get; set; }
        public int? TaskViewProjectId { get; set; }
        public int? TaskViewFilterId { get; set; }
        public int? TaskAddEditProjectId { get; set; }
        public int? IncidentViewProjectId { get; set; }
        public int? IncidentViewFilterId { get; set; }
        public int? IncidentAddEditProjectId { get; set; }
        public int? WikiPageViewProjectId { get; set; }
        public int? WikiPageAddEditProjectId { get; set; }
    }
}
