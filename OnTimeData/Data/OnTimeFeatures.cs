using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class OnTimeFeatures
    {
        [Key]
        public int FeatureId { get; set; }
        public int ProjectId { get; set; }
        public int? CreatorId { get; set; }
        [StringLength(50)]
        public string PlannedBuildNumber { get; set; }
        public int? AssignedToId { get; set; }
        public int? RequestedById { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public float? EstimatedDuration { get; set; }
        public int? DurationUnitTypeId { get; set; }
        public float? ActualDuration { get; set; }
        public int? ActualUnitTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompletionDate { get; set; }
        public int? PriorityTypeId { get; set; }
        public int? StatusTypeId { get; set; }
        public byte? PercentComplete { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName = "ntext")]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        public int? WorkflowStepId { get; set; }
        public int? LastUpdatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
        public bool? PubliclyViewable { get; set; }
        public int? RequestedByCustomerContactId { get; set; }
        public bool? Archived { get; set; }
        public float? RemainingDuration { get; set; }
        public int? RemainingUnitTypeId { get; set; }
        public int? ReleaseId { get; set; }
    }
}
