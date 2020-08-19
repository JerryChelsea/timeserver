using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("webpages_UsersInRoles")]
    public partial class WebpagesUsersInRoles
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(WebpagesRoles.WebpagesUsersInRoles))]
        public virtual WebpagesRoles Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserProfile.WebpagesUsersInRoles))]
        public virtual UserProfile User { get; set; }
    }
}
