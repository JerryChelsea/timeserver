using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("aspnet_PersonalizationPerUser")]
    public partial class AspnetPersonalizationPerUser
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? PathId { get; set; }
        public Guid? UserId { get; set; }
        [Required]
        [Column(TypeName = "image")]
        public byte[] PageSettings { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }

        [ForeignKey(nameof(PathId))]
        [InverseProperty(nameof(AspnetPaths.AspnetPersonalizationPerUser))]
        public virtual AspnetPaths Path { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspnetUsers.AspnetPersonalizationPerUser))]
        public virtual AspnetUsers User { get; set; }
    }
}
