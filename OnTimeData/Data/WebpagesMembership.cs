using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    [Table("webpages_Membership")]
    public partial class WebpagesMembership
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [StringLength(128)]
        public string ConfirmationToken { get; set; }
        public bool? IsConfirmed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PasswordChangedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string PasswordSalt { get; set; }
        [StringLength(128)]
        public string PasswordVerificationToken { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }
}
