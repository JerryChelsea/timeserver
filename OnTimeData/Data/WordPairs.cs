using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class WordPairs
    {
        [Column("WORDLINKID")]
        public int Wordlinkid { get; set; }
        public int LinkTypeId { get; set; }
        [Column("WordID")]
        public int WordId { get; set; }
        [Column("WordTypeID")]
        public int WordTypeId { get; set; }
        [Required]
        [StringLength(10)]
        public string Language { get; set; }
        [Required]
        [StringLength(500)]
        public string Phrase { get; set; }
        [StringLength(500)]
        public string Example { get; set; }
        [StringLength(4095)]
        public string Note { get; set; }
        public double? Random { get; set; }
        [Column("WORDID1")]
        public int Wordid1 { get; set; }
        [Column("WordTypeID1")]
        public int WordTypeId1 { get; set; }
        [Required]
        [Column("LANGUAGE1")]
        [StringLength(10)]
        public string Language1 { get; set; }
        [Required]
        [StringLength(500)]
        public string Phrase1 { get; set; }
        [StringLength(500)]
        public string Example1 { get; set; }
        [StringLength(4095)]
        public string Note1 { get; set; }
    }
}
