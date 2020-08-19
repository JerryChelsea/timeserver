using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class TagReference
    {
        [Column("tagid")]
        public int Tagid { get; set; }
        [Key]
        [Column("tag")]
        [StringLength(50)]
        public string Tag { get; set; }
        [Column("tagclass")]
        [StringLength(10)]
        public string Tagclass { get; set; }
        [Column("fontsize")]
        [StringLength(20)]
        public string Fontsize { get; set; }
    }
}
