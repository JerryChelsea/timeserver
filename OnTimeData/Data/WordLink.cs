using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class WordLink
    {
        [Column("WordLinkID")]
        public int WordLinkId { get; set; }
        [Key]
        [Column("WordID1")]
        public int WordId1 { get; set; }
        [Key]
        [Column("WordID2")]
        public int WordId2 { get; set; }
        [Column("LevelID")]
        public int? LevelId { get; set; }

        [ForeignKey(nameof(WordId1))]
        [InverseProperty(nameof(Word.WordLinkWordId1Navigation))]
        public virtual Word WordId1Navigation { get; set; }
        [ForeignKey(nameof(WordId2))]
        [InverseProperty(nameof(Word.WordLinkWordId2Navigation))]
        public virtual Word WordId2Navigation { get; set; }
    }
}
