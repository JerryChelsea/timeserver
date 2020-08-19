using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class EntityUnitTree
    {
        [Column("OwnerEntityID")]
        public int? OwnerEntityId { get; set; }
        [Column("ParentEntityID")]
        public int? ParentEntityId { get; set; }
        [Column("EntityUnitID")]
        public int EntityUnitId { get; set; }
        [Required]
        [StringLength(100)]
        public string LocationName { get; set; }
        [StringLength(300)]
        public string FullName { get; set; }
        [Column("EntityUnitTypeID")]
        public int EntityUnitTypeId { get; set; }
        public int Level { get; set; }
        [Required]
        [Column("sortcol")]
        [MaxLength(50)]
        public byte[] Sortcol { get; set; }
    }
}
