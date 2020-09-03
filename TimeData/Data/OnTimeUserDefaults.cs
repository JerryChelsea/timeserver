using System;
using System.ComponentModel.DataAnnotations;

namespace OnTimeData.Data
{
    public class OnTimeUserDefaults
    {
        [Key]
        public Guid UserId { get; set; }
        
        public int? DefaultCustomerId { get; set; }
    }
}
