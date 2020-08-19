using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("smSubCategory")]
    public partial class SmSubCategory
    {
        public SmSubCategory()
        {
            SmProduct = new HashSet<SmProduct>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Key]
        [Column("SubCategoryID")]
        public int SubCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string SubCatName { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(SmCategory.SmSubCategory))]
        public virtual SmCategory Category { get; set; }
        [InverseProperty("SmSubCategory")]
        public virtual ICollection<SmProduct> SmProduct { get; set; }
    }
}
