using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("ArticleXSubCategory")]
    public partial class ArticleXsubCategory
    {
        [Key]
        [Column("ArticleXSubCategoryID")]
        public int ArticleXsubCategoryId { get; set; }
        [Column("ArticleID")]
        public int ArticleId { get; set; }
        [Column("ArticleSubCategoryID")]
        public int ArticleSubCategoryId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [InverseProperty("ArticleXsubCategory")]
        public virtual Article Article { get; set; }
        [ForeignKey(nameof(ArticleSubCategoryId))]
        [InverseProperty("ArticleXsubCategory")]
        public virtual ArticleSubCategory ArticleSubCategory { get; set; }
    }
}
