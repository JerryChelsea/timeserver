using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Tag
    {
        [Key]
        [StringLength(10)]
        public string PageRef { get; set; }
        [Key]
        [StringLength(10)]
        public string SubPageRef { get; set; }
        [Key]
        [Column("TagID")]
        public int TagId { get; set; }
    }
}
