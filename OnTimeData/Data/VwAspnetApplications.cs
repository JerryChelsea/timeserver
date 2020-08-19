using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class VwAspnetApplications
    {
        [Required]
        [StringLength(256)]
        public string ApplicationName { get; set; }
        [Required]
        [StringLength(256)]
        public string LoweredApplicationName { get; set; }
        public Guid ApplicationId { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
    }
}
