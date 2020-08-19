using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("smCategory")]
    public partial class SmCategory
    {
        public SmCategory()
        {
            SmProduct = new HashSet<SmProduct>();
            SmSubCategory = new HashSet<SmSubCategory>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CatName { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<SmProduct> SmProduct { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<SmSubCategory> SmSubCategory { get; set; }
    }
}
