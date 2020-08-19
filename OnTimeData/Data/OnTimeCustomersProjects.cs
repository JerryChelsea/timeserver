using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class OnTimeCustomersProjects
    {
        [Key]
        public int CustomerId { get; set; }
        [Key]
        public int ProjectId { get; set; }
    }
}
