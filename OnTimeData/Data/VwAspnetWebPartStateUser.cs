﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class VwAspnetWebPartStateUser
    {
        public Guid? PathId { get; set; }
        public Guid? UserId { get; set; }
        public int? DataSize { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }
    }
}
