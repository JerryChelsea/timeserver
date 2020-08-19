using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeData
{
    public partial class OnTimeWorkLog
    {
        [Key]
        public int WorkLogId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime WorkLogDateTime { get; set; }
        public int ItemId { get; set; }
        public int? ItemTypeId { get; set; }
        public int? UserId { get; set; }
        public float WorkDone { get; set; }
        public int? WorkUnitTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        public int? WorkLogTypeId { get; set; }
    }
}
