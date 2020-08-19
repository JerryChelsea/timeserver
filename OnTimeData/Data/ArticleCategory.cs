using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class ArticleCategory
    {
        public ArticleCategory()
        {
            ArticleSubCategory = new HashSet<ArticleSubCategory>();
            ArticleXcategory = new HashSet<ArticleXcategory>();
        }

        [Key]
        [Column("ArticleCategoryID")]
        public int ArticleCategoryId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(50)]
        public string ShortName { get; set; }

        [InverseProperty("ArticleCategory")]
        public virtual ICollection<ArticleSubCategory> ArticleSubCategory { get; set; }
        [InverseProperty("ArticleCategory")]
        public virtual ICollection<ArticleXcategory> ArticleXcategory { get; set; }
    }
}
