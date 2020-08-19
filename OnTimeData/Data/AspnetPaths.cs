using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("aspnet_Paths")]
    public partial class AspnetPaths
    {
        public AspnetPaths()
        {
            AspnetPersonalizationPerUser = new HashSet<AspnetPersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }
        [Key]
        public Guid PathId { get; set; }
        [Required]
        [StringLength(256)]
        public string Path { get; set; }
        [Required]
        [StringLength(256)]
        public string LoweredPath { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        [InverseProperty(nameof(AspnetApplications.AspnetPaths))]
        public virtual AspnetApplications Application { get; set; }
        [InverseProperty("Path")]
        public virtual AspnetPersonalizationAllUsers AspnetPersonalizationAllUsers { get; set; }
        [InverseProperty("Path")]
        public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
    }
}
