using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            WebpagesUsersInRoles = new HashSet<WebpagesUsersInRoles>();
        }

        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(56)]
        public string UserName { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<WebpagesUsersInRoles> WebpagesUsersInRoles { get; set; }
    }
}
