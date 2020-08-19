using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Rating
    {
        [Key]
        [Column("RatingID")]
        public int RatingId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
