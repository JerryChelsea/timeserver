using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class VwAspnetUsersInRoles
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
