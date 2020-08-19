using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("webpages_Roles")]
    public partial class WebpagesRoles
    {
        public WebpagesRoles()
        {
            WebpagesUsersInRoles = new HashSet<WebpagesUsersInRoles>();
        }

        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(256)]
        public string RoleName { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<WebpagesUsersInRoles> WebpagesUsersInRoles { get; set; }
    }
}
