using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Wordlinklist
    {
        [Column("WORDID")]
        public int Wordid { get; set; }
        [Column("WORDLINKID")]
        public int Wordlinkid { get; set; }
        [Required]
        [StringLength(10)]
        public string Language { get; set; }
        [Column("LEVELID")]
        public int? Levelid { get; set; }
    }
}
