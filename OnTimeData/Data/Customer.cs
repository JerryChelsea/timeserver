using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class Customer
    {
        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(2)]
        public string State { get; set; }
        [Column("ZIP")]
        [StringLength(5)]
        public string Zip { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        public int? RewardPoints { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
    }
}
