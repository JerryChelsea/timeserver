using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class VwAspnetRoles
    {
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        [Required]
        [StringLength(256)]
        public string RoleName { get; set; }
        [Required]
        [StringLength(256)]
        public string LoweredRoleName { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
    }
}
