using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class PageRefArticleCategory
    {
        [Key]
        [StringLength(50)]
        public string PageRef { get; set; }
        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
    }
}
