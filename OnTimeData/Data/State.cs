using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class State
    {
        [Key]
        [Column("StateID")]
        public int StateId { get; set; }
        [StringLength(4)]
        public string StateAbbr { get; set; }
        [StringLength(50)]
        public string StateName { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
    }
}
