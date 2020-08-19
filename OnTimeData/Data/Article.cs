using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Article
    {
        public Article()
        {
            ArticleXcategory = new HashSet<ArticleXcategory>();
            ArticleXsubCategory = new HashSet<ArticleXsubCategory>();
        }

        [Key]
        [Column("ArticleID")]
        public int ArticleId { get; set; }
        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Author { get; set; }
        [Column("ArticleTypeID")]
        public int ArticleTypeId { get; set; }
        public string Link { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ArticleDate { get; set; }
        [Column("RatingID")]
        public int RatingId { get; set; }
        [Column("ActionTypeID")]
        public int ActionTypeId { get; set; }
        public int? CertRelated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column("CreatedBY")]
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int Deleted { get; set; }

        [InverseProperty("Article")]
        public virtual ArticleNotes ArticleNotes { get; set; }
        [InverseProperty("Article")]
        public virtual ICollection<ArticleXcategory> ArticleXcategory { get; set; }
        [InverseProperty("Article")]
        public virtual ICollection<ArticleXsubCategory> ArticleXsubCategory { get; set; }
    }
}
