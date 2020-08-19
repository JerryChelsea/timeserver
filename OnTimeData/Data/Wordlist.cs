using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Wordlist
    {
        [Column("WORDID")]
        public int Wordid { get; set; }
        [Column("WORDLINKID")]
        public int Wordlinkid { get; set; }
        [Column("LevelID")]
        public int? LevelId { get; set; }
        [Column("WORDTYPEID")]
        public int Wordtypeid { get; set; }
        [Column("PHRASE")]
        [StringLength(500)]
        public string Phrase { get; set; }
    }
}
