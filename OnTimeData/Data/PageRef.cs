using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class PageRef
    {
        public PageRef()
        {
            SubPageRef = new HashSet<SubPageRef>();
        }

        [Key]
        [Column("PageRef")]
        [StringLength(15)]
        public string PageRef1 { get; set; }

        [InverseProperty("PageRefNavigation")]
        public virtual ICollection<SubPageRef> SubPageRef { get; set; }
    }
}
