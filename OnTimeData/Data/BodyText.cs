using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class BodyText
    {
        [Key]
        [Column("BodyID")]
        public int BodyId { get; set; }
        [Required]
        [StringLength(50)]
        public string BodyPage { get; set; }
        [Required]
        [StringLength(50)]
        public string BodySubPage { get; set; }
        [Column("BodyText", TypeName = "text")]
        public string BodyText1 { get; set; }
        [Column(TypeName = "text")]
        public string BodyExample { get; set; }
        [StringLength(400)]
        public string Controller { get; set; }
        [StringLength(400)]
        public string RightMenu { get; set; }
        [StringLength(200)]
        public string LeftMenu { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
