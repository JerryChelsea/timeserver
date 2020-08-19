using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class SubPageRef
    {
        [Key]
        [StringLength(15)]
        public string PageRef { get; set; }
        [Key]
        [Column("SubPageRef")]
        [StringLength(10)]
        public string SubPageRef1 { get; set; }

        [ForeignKey(nameof(PageRef))]
        [InverseProperty("SubPageRef")]
        public virtual PageRef PageRefNavigation { get; set; }
    }
}
