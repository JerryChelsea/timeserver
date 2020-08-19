using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class UsedWords
    {
        [Key]
        [Column("WORDID")]
        public int Wordid { get; set; }
        public double? Random { get; set; }
    }
}
