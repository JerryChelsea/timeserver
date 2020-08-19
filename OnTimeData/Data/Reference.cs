using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Reference
    {
        [Key]
        [Column("RefID")]
        public int RefId { get; set; }
        [Column("RefTypeID")]
        public int RefTypeId { get; set; }
        [Required]
        [StringLength(10)]
        public string PageRef { get; set; }
        [StringLength(10)]
        public string SubPageRef { get; set; }
        [Required]
        [Column("Reference")]
        [StringLength(500)]
        public string Reference1 { get; set; }
        [StringLength(500)]
        public string WebSite { get; set; }
        [StringLength(500)]
        public string Tags { get; set; }
    }
}
