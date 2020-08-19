using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("ArticleXCategory")]
    public partial class ArticleXcategory
    {
        [Key]
        [Column("ArticleXCategoryID")]
        public int ArticleXcategoryId { get; set; }
        [Column("ArticleID")]
        public int ArticleId { get; set; }
        [Column("ArticleCategoryID")]
        public int ArticleCategoryId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [InverseProperty("ArticleXcategory")]
        public virtual Article Article { get; set; }
        [ForeignKey(nameof(ArticleCategoryId))]
        [InverseProperty("ArticleXcategory")]
        public virtual ArticleCategory ArticleCategory { get; set; }
    }
}
