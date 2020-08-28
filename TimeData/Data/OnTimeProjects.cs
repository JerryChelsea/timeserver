using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeData
{
    public partial class OnTimeProjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public int? ParentId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        public bool? IsActive { get; set; }
        public string Path { get; set; }
    }
}
