using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class ArticleSubCategory
    {
        public ArticleSubCategory()
        {
            ArticleXsubCategory = new HashSet<ArticleXsubCategory>();
        }

        [Key]
        [Column("ArticleSubCategoryID")]
        public int ArticleSubCategoryId { get; set; }
        [Column("ArticleCategoryID")]
        public int ArticleCategoryId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(30)]
        public string ShortName { get; set; }

        [ForeignKey(nameof(ArticleCategoryId))]
        [InverseProperty("ArticleSubCategory")]
        public virtual ArticleCategory ArticleCategory { get; set; }
        [InverseProperty("ArticleSubCategory")]
        public virtual ICollection<ArticleXsubCategory> ArticleXsubCategory { get; set; }
    }
}
