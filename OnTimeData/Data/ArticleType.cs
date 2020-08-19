using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class ArticleType
    {
        [Key]
        [Column("ArticleTypeID")]
        public int ArticleTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
