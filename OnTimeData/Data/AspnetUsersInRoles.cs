using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("aspnet_UsersInRoles")]
    public partial class AspnetUsersInRoles
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public Guid RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspnetRoles.AspnetUsersInRoles))]
        public virtual AspnetRoles Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspnetUsers.AspnetUsersInRoles))]
        public virtual AspnetUsers User { get; set; }
    }
}
