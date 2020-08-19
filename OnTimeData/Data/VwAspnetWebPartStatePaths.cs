using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class VwAspnetWebPartStatePaths
    {
        public Guid ApplicationId { get; set; }
        public Guid PathId { get; set; }
        [Required]
        [StringLength(256)]
        public string Path { get; set; }
        [Required]
        [StringLength(256)]
        public string LoweredPath { get; set; }
    }
}
