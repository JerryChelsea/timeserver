using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("aspnet_Applications")]
    public partial class AspnetApplications
    {
        public AspnetApplications()
        {
            AspnetMembership = new HashSet<AspnetMembership>();
            AspnetPaths = new HashSet<AspnetPaths>();
            AspnetRoles = new HashSet<AspnetRoles>();
            AspnetUsers = new HashSet<AspnetUsers>();
        }

        [Required]
        [StringLength(256)]
        public string ApplicationName { get; set; }
        [Required]
        [StringLength(256)]
        public string LoweredApplicationName { get; set; }
        [Key]
        public Guid ApplicationId { get; set; }
        [StringLength(256)]
        public string Description { get; set; }

        [InverseProperty("Application")]
        public virtual ICollection<AspnetMembership> AspnetMembership { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<AspnetPaths> AspnetPaths { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<AspnetRoles> AspnetRoles { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<AspnetUsers> AspnetUsers { get; set; }
    }
}
