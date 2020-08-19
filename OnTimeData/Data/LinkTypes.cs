using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class LinkTypes
    {
        public int LinkTypeId { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string FrontTitle { get; set; }
        [Required]
        [StringLength(50)]
        public string BackTitle { get; set; }
    }
}
