using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class ArticleNotes
    {
        [Key]
        [Column("ArticleID")]
        public int ArticleId { get; set; }
        [Column(TypeName = "text")]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Modified { get; set; }
        [Column("CreatedBY")]
        public int CreatedBy { get; set; }
        [Column("ModifiedBY")]
        public int ModifiedBy { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [InverseProperty("ArticleNotes")]
        public virtual Article Article { get; set; }
    }
}
