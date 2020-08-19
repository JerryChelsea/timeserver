using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("smProduct")]
    public partial class SmProduct
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProdName { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("SubCategoryID")]
        public int? SubCategoryId { get; set; }
        [StringLength(20)]
        public string SaleUnit { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SalePrice { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(SmCategory.SmProduct))]
        public virtual SmCategory Category { get; set; }
        [ForeignKey("CategoryId,SubCategoryId")]
        [InverseProperty("SmProduct")]
        public virtual SmSubCategory SmSubCategory { get; set; }
    }
}
