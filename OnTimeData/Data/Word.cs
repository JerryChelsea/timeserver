using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Word
    {
        public Word()
        {
            WordLinkWordId1Navigation = new HashSet<WordLink>();
            WordLinkWordId2Navigation = new HashSet<WordLink>();
        }

        [Key]
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

        [InverseProperty(nameof(WordLink.WordId1Navigation))]
        public virtual ICollection<WordLink> WordLinkWordId1Navigation { get; set; }
        [InverseProperty(nameof(WordLink.WordId2Navigation))]
        public virtual ICollection<WordLink> WordLinkWordId2Navigation { get; set; }
    }
}
