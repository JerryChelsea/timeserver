using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Schedule
    {
        [Key]
        public int Customerid { get; set; }
        [Key]
        [Column("SchedID")]
        public int SchedId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SchedDateTime { get; set; }
        [StringLength(200)]
        public string SchedName { get; set; }
    }
}
