using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("aspnet_SchemaVersions")]
    public partial class AspnetSchemaVersions
    {
        [Key]
        [StringLength(128)]
        public string Feature { get; set; }
        [Key]
        [StringLength(128)]
        public string CompatibleSchemaVersion { get; set; }
        public bool IsCurrentVersion { get; set; }
    }
}
